using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.FaturamentoContratos.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Relatorios.Aplication.FaturamentoContratos.Services
{
    public interface IGerarFaturamentoContratoService
    {
        Task<Result<List<ConsultaGeracaoFatumentoResult>, Error>> ConsultarFaturamento(ConsultaGeracaoFaturamentoRequest request);
    }

    public class GerarFaturamentoContratoService : IGerarFaturamentoContratoService
    {
        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;
        private readonly IErpRepositorioGenerico _repositorioGenerico;
        private readonly AnaliseFaturamentoContratoService _analiseFaturamentoContratoServiceNovo;

        private List<BANCO_FATURAMENTO> _listaBancos;
        private List<CONVENIO_BANCARIO_FATURAMENTO> _listaConvenioBancario;
        private List<TIPO_PAGAMENTO_FATURAMENTO> _listaTipoPagamento;

        public GerarFaturamentoContratoService(
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao,
            IErpRepositorioGenerico repositorioGenerico,
            AnaliseFaturamentoContratoService analiseFaturamentoContratoServiceNovo)
        {
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
            _repositorioGenerico = repositorioGenerico;
            _analiseFaturamentoContratoServiceNovo = analiseFaturamentoContratoServiceNovo;
        }

        public async Task<Result<List<ConsultaGeracaoFatumentoResult>, Error>> ConsultarFaturamento(ConsultaGeracaoFaturamentoRequest request)
        {
            var listaResultado = new List<ConsultaGeracaoFatumentoResult>();
            if (request.IncluirNaoFaturados)
            {
                var resultado = await ConsultarNaoFaturados(request);
                var model = resultado.Select(x => new ConsultaGeracaoFatumentoResult(x)).ToList();
                listaResultado.AddRange(model);
            }

            if (request.IncluirFaturados)
            {
                var resultado = ConsultarFaturados(request.CodEmpresa, request.CodPessoa, request.DtaInicio, request.DtaFinal, request.NumDiaFaturamento);
                listaResultado.AddRange(resultado);
            }

            return listaResultado;
        }


        private async Task<List<BANCO_FATURAMENTO>> BancosCachedOuBusca(int codEmpresa)
        {
            if (_listaBancos == null)
            {
                var empresaPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(codEmpresa);
                var empresaPadraoBancos = empresaPadrao[EmpresaPadrao.Bancos].CodEmpresaPadrao;

                var query = _repositorioGenerico.Query<GE_BANCOS>().Where(b => b.COD_EMPRESA == empresaPadraoBancos);
                _listaBancos = BANCO_FATURAMENTO.MapToModel(query).ToList();
            }

            return _listaBancos;
        }

        private async Task<List<TIPO_PAGAMENTO_FATURAMENTO>> tipoPagamentoCachedOuBusca(int codEmpresa)
        {
            if (_listaBancos == null)
            {
                var empresaPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(codEmpresa);
                var codEmpresaPadrao = empresaPadrao[EmpresaPadrao.TipoPagamento].CodEmpresaPadrao;

                var query = _repositorioGenerico.Query<GE_TIPO_PAGAMENTO>().Where(b => b.COD_EMPRESA == codEmpresaPadrao);
                _listaTipoPagamento = TIPO_PAGAMENTO_FATURAMENTO.MapToModel(query).ToList();
            }

            return _listaTipoPagamento;
        }


        private async Task<List<CONVENIO_BANCARIO_FATURAMENTO>> cachedConveniosBancosOuBusca()
        {
            if (_listaConvenioBancario == null)
            {
                var query = _repositorioGenerico.Query<CR_CONVENIOS_BANCARIOS>();
                _listaConvenioBancario = CONVENIO_BANCARIO_FATURAMENTO.QueryToModel(query).ToList();
            }

            return _listaConvenioBancario;
        }
        

        private async Task<IEnumerable<PreFaturamento>> ConsultarNaoFaturados(ConsultaGeracaoFaturamentoRequest request)
        {
            var resultadoAnaliseCliente = _analiseFaturamentoContratoServiceNovo.ConsultarFaturamentoPorPessoa(
                request.CodEmpresa,
                request.CodPessoa,
                request.DtaInicio,
                request.DtaFinal,
                request.NumDiaFaturamento,
                request.ListarNaoFaturadosEmAtraso);

            var listaResultado = new List<PreFaturamento>();
            foreach (var item in resultadoAnaliseCliente)
            {
                var resultado = await AnaliseToPreFaturamento(item, request);
                listaResultado.AddRange(resultado);
            }

            return listaResultado;
        }


        private async Task<IEnumerable<PreFaturamento>> AnaliseToPreFaturamento(ResultadoAnaliseCliente resultadoAnaliseCliente, ConsultaGeracaoFaturamentoRequest request)
        {
            resultadoAnaliseCliente.ListaContratos = AgruparFaturamento(resultadoAnaliseCliente.ListaContratos, false);

            var faturamentoComContrato = await processarFaturamentoDeContrato(request.CodEmpresa, resultadoAnaliseCliente.ListaContratos);
            var faturamentoSemContrato = await processarFaturamentoSemContrato(request.CodEmpresa, resultadoAnaliseCliente.ListaLancamentos);

            var listaFaturamento = faturamentoComContrato
                .Concat(faturamentoSemContrato).ToList();

            if (request.ListarNaoFaturadosEmAtraso)
                listaFaturamento = listaFaturamento.Where(x => x.DtaEmissao <= request.DtaFinal).ToList();
            else
                listaFaturamento = listaFaturamento
                    .Where(x => x.DtaEmissao >= request.DtaInicio && x.DtaEmissao <= request.DtaFinal).ToList();

            return listaFaturamento;
        }

        private async Task<IEnumerable<PreFaturamento>> processarFaturamentoSemContrato(int codEmpresa, List<ResultadoAnaliseLancamentos> listaLancamentosAvulsos)
        {
            var listaItensFaturaSemContrato = listaLancamentosAvulsos.Select(x => new ItemFaturamento(x));
            var listaFaturaSemContrato = new List<PreFaturamento>();

            foreach (var item in listaItensFaturaSemContrato)
            {
                var fatura = new PreFaturamento(item);

                if (item.Vencimentos?.Any() == true)
                    fatura.AdicionarVencimentos(item.Vencimentos.ToArray());
                else
                    fatura.AdicionarVencimentos(item.DtaEmissao);

                fatura.TipoPagtoSugerido = (await tipoPagamentoCachedOuBusca(codEmpresa)).FirstOrDefault(t => t.CODIGO == item.CodTipoPagamento)!;
                fatura.BancoSugerido = await retornaBancoSugeridoFaturamento(codEmpresa);

                fatura.DtaAnaliseInicial = DateTime.Today;
                fatura.DtaAnaliseFinal = DateTime.Today;

                listaFaturaSemContrato.Add(fatura);
            }

            var listaAgrupamento = AgruparFaturamentos(listaFaturaSemContrato);
            return listaAgrupamento;
        }

        private List<ConsultaGeracaoFatumentoResult> ConsultarFaturados(int codEmpresa, int? codPessoa, DateTime dtaInicial, DateTime dtaFinal, int numDiaFaturamento)
        {
            var queryFaturados = _repositorioGenerico.Query<FT_FATURA>().Where(x =>
                x.COD_EMPRESA == codEmpresa
                && (x.TIP_EXCLUIDO ?? false) != true
                && x.DTA_FATURA <= dtaFinal
                && x.DTA_FATURA >= dtaInicial);

            if (codPessoa.HasValue)
                queryFaturados = queryFaturados.Where(f => f.COD_PESSOA == codPessoa);

            if (numDiaFaturamento != 0)
                queryFaturados = queryFaturados.Where(x =>
                    x.FT_FATURA_ITENS.Any(itemFatura => itemFatura.COD_CONTRATO_ITENSNavigation.COD_CONTRATONavigation.NUM_DIA_EMISSAO == numDiaFaturamento)
                    || x.DTA_FATURA.Day == numDiaFaturamento || numDiaFaturamento == 0);


            var resultadoPesquisa = queryFaturados
                .Select(f => new FaturadosModel()
                {
                    CodFatura = f.COD_FATURA,
                    CodPessoa = f.COD_PESSOA,
                    DesPessoa = f.COD_PESSOANavigation.DES_PESSOA,
                    VlrFaturado = f.VLR_FATURA.GetValueOrDefault(),
                    DtaEmissao = f.DTA_FATURA,
                    DtaAnaliseFinal = f.DTA_ANALISE_FINAL,
                    DtaAnaliseInicial = f.DTA_ANALISE_INICIAL,
                    NumNota = f.FT_FATURA_TITULOS.Select(x => x.COD_TITULONavigation.COD_NOTANavigation.NUM_NOTA).FirstOrDefault(),
                    VlrDesconto = f.VLR_DESCONTO.GetValueOrDefault(),
                    DtaGeracao = f.DTA_GERACAO,
                    PrimeiroTitulo = f.FT_FATURA_TITULOS.Select(x => new TitulosFaturamentoGerado()
                    {
                        CodTitulo = x.COD_TITULO,
                        NumNota = x.COD_TITULONavigation.COD_NOTA,
                        CodBanco = x.COD_TITULONavigation.COD_BANCO,
                        CodNota = x.COD_TITULONavigation.COD_NOTA,
                        CodTipoPagamento = x.COD_TITULONavigation.COD_TIPO_PAGAMENTO,
                        DesTipoPagamento = x.COD_TITULONavigation.COD_TIPO_PAGAMENTONavigation.DES_TIPO_PAGAMENTO,
                        IndSituacao = x.COD_TITULONavigation.IND_SITUACAO,
                    }).FirstOrDefault()!,
                    TipExcluido = f.TIP_EXCLUIDO ?? false,
                    VlrDescontoTitulos = f.FT_FATURA_TITULOS.Sum(x => x.COD_TITULONavigation.VLR_DESCONTO.GetValueOrDefault()),
                    Vencimentos = f.FT_FATURA_TITULOS.Select(t => t.COD_TITULONavigation.DTA_VENCIMENTO).ToList(),
                    CodBancoPessoa = f.COD_PESSOANavigation.COD_BANCO,
                    DesBanco = f.COD_PESSOANavigation.COD_BANCONavigation.DES_BANCO,
                    Itens = f.FT_FATURA_ITENS.Select(i => new FaturamentoGeracaoFaturamentoItem()
                    {
                        COD_CONTRATO_ITENS = i.COD_CONTRATO_ITENS,
                        COD_LANCAMENTO = i.COD_LANCAMENTO,
                        VLR_ITEM = i.VLR_ITEM ?? 0,
                        DtaEmissao = i.COD_LANCAMENTONavigation.DTA_COBRANCA,
                        DtaVencimento = i.COD_LANCAMENTONavigation.PS_LANCAMENTOS_VENCIMENTO.FirstOrDefault().DTA_VENCIMENTO,
                        HMS_FATURADOS = i.HMS_FATURADOS ?? 0,
                        IN_TIPO_CONTRATO = i.COD_CONTRATO_ITENSNavigation.IND_TIPO_CONTRATO,
                        DES_PRODUTO = i.COD_CONTRATO_ITENSNavigation.COD_PRODUTONavigation.DES_PRODUTO,
                    }).ToList(),
                    CodContratosAgrupados = f.FT_FATURA_ITENS.Select(i => i.COD_CONTRATO_ITENSNavigation.COD_CONTRATONavigation.COD_CONTRATO).Distinct().ToList(),
                    IndFixado = f.FT_FATURA_ITENS.FirstOrDefault().COD_CONTRATO_ITENSNavigation.COD_CONTRATONavigation.IND_FIXADO
                })
                .Select(f => new ConsultaGeracaoFatumentoResult(f)).ToList();

            return resultadoPesquisa;
        }


        private IEnumerable<PreFaturamento> AgruparFaturamentos(List<PreFaturamento> listaFaturas)
        {
            var resultadoAgrupamento = new List<PreFaturamento>();

            foreach (var fatura in listaFaturas)
            {
                var faturaAgrupado = resultadoAgrupamento
                                        .Where(x => x.DtaVencimentos.Count() == fatura.DtaVencimentos.Count()
                                        && x.DtaVencimentos.FirstOrDefault() == fatura.DtaVencimentos.FirstOrDefault()
                                        && x.DtaVencimentos.FirstOrDefault() == fatura.DtaVencimentos.FirstOrDefault())?.FirstOrDefault();

                if (faturaAgrupado == null)
                {
                    resultadoAgrupamento.Add(fatura);
                    continue;
                }

                fatura.ListaItens.ForEach(x => faturaAgrupado.AdicionarItem(x));
            }

            return resultadoAgrupamento;
        }

        private async Task<List<PreFaturamento>> processarFaturamentoDeContrato(int codEmpresa, List<ResultadoAnaliseContratos> listaAnaliseContratos)
        {
            var listaFaturamento = new List<PreFaturamento>();

            var franquias = listaAnaliseContratos?.FirstOrDefault()?.ListaFranquias;

            var analiseComContratoAgrupada = AgruparFaturamento(listaAnaliseContratos, false);
            foreach (var resultadoAnalise in analiseComContratoAgrupada)
            {
                var contrato = resultadoAnalise.Contrato;

                var dtaEmissao = resultadoAnalise.DtaEmissao;
                var dtaVenciamento = CalcularDtaVencimento(resultadoAnalise.Contrato, dtaEmissao);

                var itensFaturamento = new List<ItemFaturamento>();
                itensFaturamento.AddRange(resultadoAnalise.ListaLancamentos.Select(x => new ItemFaturamento(x, franquias, contrato)));
                itensFaturamento.AddRange(resultadoAnalise.ListaItensValorContrato.Select(x => new ItemFaturamento(x, franquias, contrato)));

                var itensCobrancaFutura = new List<ItemFaturamento>();
                itensCobrancaFutura.AddRange(resultadoAnalise.ListaLancamentosNoPeriodo.Select(x => new ItemFaturamento(x, franquias, contrato)));

                var itensAteOPeriodo = new List<ItemFaturamento>();
                itensAteOPeriodo.AddRange(resultadoAnalise.ListaLancamentosAteOPeriodo.Select(x => new ItemFaturamento(x, franquias, contrato)));

                var novoFaturamento = new PreFaturamento
                    (
                        contrato,
                        dtaEmissao,
                        itensFaturamento,
                        itensCobrancaFutura,
                        resultadoAnalise.BancoFranquia,
                        itensAteOPeriodo
                    );

                novoFaturamento.AdicionarCodContratoAgruado(resultadoAnalise.ContratosAgrupados.ToArray());
                novoFaturamento.AdicionarVencimentos(dtaVenciamento);

                novoFaturamento.DtaAnaliseFinal = resultadoAnalise.DtaAnaliseFinal;
                novoFaturamento.DtaAnaliseInicial = resultadoAnalise.DtaAnaliseInicial;
                novoFaturamento.DtaEmissao = resultadoAnalise.DtaEmissao;
                novoFaturamento.Contrato = resultadoAnalise.Contrato;

                var tipoPagtoSugerido = resultadoAnalise.Contrato.COD_TIPO_PAGAMENTO ?? 0;
                if (tipoPagtoSugerido == 0)
                    tipoPagtoSugerido = resultadoAnalise.Contrato.COD_TIPO_PAGAMENTO_PESSOA ?? 0;

                novoFaturamento.TipoPagtoSugerido = (await tipoPagamentoCachedOuBusca(codEmpresa)).FirstOrDefault(t => t.CODIGO == tipoPagtoSugerido)!;
                //_repositorioGenerico.GetSingleById<GE_TIPO_PAGAMENTO>(tipoPagtoSugerido);
                novoFaturamento.BancoSugerido = await retornaBancoSugeridoFaturamento(codEmpresa, contrato);

                var convenioContrato = cachedConveniosBancosOuBusca().Result.FirstOrDefault(c => c.CODIGO == contrato.COD_CONVENIO_BANCARIO);
                if (convenioContrato != null)
                {
                    novoFaturamento.CodConvenioContrato = convenioContrato.CODIGO;
                    novoFaturamento.DesConvenioContrato = convenioContrato.DESCRICAO ?? string.Empty;
                }

                listaFaturamento.Add(novoFaturamento);
            }

            return listaFaturamento;
        }




        private async Task<BANCO_FATURAMENTO?> retornaBancoSugeridoFaturamento(int codEmpresa, CONTRATO contrato = null)
        {
            var bancos = await BancosCachedOuBusca(codEmpresa);

            if (contrato?.COD_CONVENIO_BANCARIO.HasValue == true)
            {
                var banco = bancos.FirstOrDefault(b => b.LISTA_CONVENIOS_RELACIONADOS.Any(c => c == contrato.COD_CONVENIO_BANCARIO));

                if (banco != null)
                {
                    return banco;
                }
            }

            if (contrato?.COD_BANCO_PESSOA.HasValue == true)
            {
                var banco = bancos.FirstOrDefault(c => c.CodBanco == contrato.COD_BANCO_PESSOA);
                if (banco != null)
                {
                    return banco;
                }
            }

            if (bancos.Count == 1)
            {
                return bancos.First();
            }

            return null;
        }

        private DateTime CalcularDtaVencimento(CONTRATO contrato, DateTime dtaEmissao)
        {
            DateTime dtaVencimento;
            if (contrato.IND_REGRA_VENCIMENTO == (int)TipoRegraVencimentoContrato.DiaInformado)
            {
                var maxDiasMeses = DateTime.DaysInMonth(dtaEmissao.Year, dtaEmissao.Month);
                var numDiaVencimento = maxDiasMeses < contrato.NUM_DIA_VENCIMENTO
                    ? maxDiasMeses
                    : contrato.NUM_DIA_VENCIMENTO;

                dtaVencimento = new DateTime(dtaEmissao.Year, dtaEmissao.Month, numDiaVencimento);
                if (contrato.NUM_DIA_EMISSAO > contrato.NUM_DIA_VENCIMENTO)
                    dtaVencimento = dtaVencimento.AddMonths(1);
            }
            else
            {
                var numDiasCorridos = contrato.NUM_DIA_VENCIMENTO;
                dtaVencimento = dtaEmissao.AddDays(numDiasCorridos);
            }

            return dtaVencimento;
        }


        private List<ResultadoAnaliseContratos> AgruparFaturamento(List<ResultadoAnaliseContratos> listaResultadoContrato, bool tipAgruparReajuste = true)
        {
            var listaAgrupada = new List<ResultadoAnaliseContratos>();

            //contratos daquela franquia
            var contratosFranquia = listaResultadoContrato.Select(x => x.BancoFranquia);

            foreach (var contrato in listaResultadoContrato)
            {
                if (contrato.TipAgrupa == false)
                {
                    listaAgrupada.Add(contrato);
                    continue;
                }

                //regras de agrupamento
                var contratoAgrupado = listaAgrupada
                    .Where(x => x.TipAgrupa == true
                    && x.CodContrato != contrato.CodContrato
                    && x.Contrato.IND_RECORRENCIA == contrato.Contrato.IND_RECORRENCIA
                    && x.Contrato.NUM_DIA_EMISSAO == contrato.Contrato.NUM_DIA_EMISSAO
                    && x.DtaEmissao == contrato.DtaEmissao
                    && x.Contrato.NUM_DIA_VENCIMENTO == contrato.Contrato.NUM_DIA_VENCIMENTO
                    )?.FirstOrDefault();

                if (contratoAgrupado == null)
                {
                    listaAgrupada.Add(contrato);
                    continue;
                }

                contratoAgrupado.TipAgrupouContrato = true;

                contratoAgrupado.ContratosAgrupados.Add(contrato.Contrato);

                contratoAgrupado.CodContrato = contrato.CodContrato;
                contratoAgrupado.DtaUltimoReajuste = contratoAgrupado.DtaUltimoReajuste;
                contratoAgrupado.DtaAnaliseInicial = contrato.DtaAnaliseInicial;
                contratoAgrupado.DtaAnaliseFinal = contrato.DtaAnaliseFinal;

                //quando tem dois contratos e ele agrupa um
                if (contrato.DtaEmissao < contratoAgrupado.DtaEmissao)
                {
                    contratoAgrupado.DtaEmissao = contrato.DtaEmissao;
                }

                contratoAgrupado.TotalMinutosTrabalhados += contrato.TotalMinutosCobrados;
                contratoAgrupado.TotalMinutosCobrados += contrato.TotalMinutosCobrados;
                contratoAgrupado.TotalMinutosFaturados += contrato.TotalMinutosFaturados;
                contratoAgrupado.TotalFranquiaQuantidade += contrato.TotalFranquiaQuantidade;
                contratoAgrupado.TotalFranquiaMinutos += contrato.TotalFranquiaMinutos;
                contratoAgrupado.ListaItensValorContrato.AddRange(contrato.ListaItensValorContrato);

                contratoAgrupado.VlrTotal += contrato.VlrTotal;

                if (contratoAgrupado.ListaLancamentos == null)
                {
                    contratoAgrupado.ListaLancamentos = new List<ResultadoAnaliseLancamentos>();
                }

                foreach (var LancamentoAteOPeriodo in contrato.ListaLancamentosAteOPeriodo)
                {
                    contratoAgrupado.ListaLancamentosAteOPeriodo.Add(LancamentoAteOPeriodo);
                }

                foreach (var LancamentoNoPeriodo in contrato.ListaLancamentosNoPeriodo)
                {
                    contratoAgrupado.ListaLancamentosNoPeriodo.Add(LancamentoNoPeriodo);
                }

                contratoAgrupado.ListaLancamentos.AddRange(contrato.ListaLancamentos);
            }


            listaAgrupada.ToList().ForEach(x =>
            {
                x.ListaFranquias = contratosFranquia.ToList();
            });

            return listaAgrupada;
        }
    }
}

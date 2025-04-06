using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.FaturamentoContratos.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System.Collections.Concurrent;

namespace Relatorios.Aplication.FaturamentoContratos.Services
{
    public class AnaliseFaturamentoContratoService
    {
        private readonly IErpRepositorioGenerico _repositorioGenerico;
        private readonly IRepositorioEmpresasPadrao _empresasPadrao;

        public AnaliseFaturamentoContratoService(IErpRepositorioGenerico repositorioGenerico, IRepositorioEmpresasPadrao empresasPadrao)
        {
            _repositorioGenerico = repositorioGenerico;
            _empresasPadrao = empresasPadrao;
        }

        public List<ResultadoAnaliseCliente> ConsultarFaturamentoPorPessoa(int codEmpresa, int? codPessoa, DateTime dtaInicio, DateTime? dtaFim, int numDiaEmissao = 0, bool tipListarNaoFaturadosEmAtraso = true)
        {
            var analiseSemContrato = ConsultarLancamentosSemContratos(codEmpresa, codPessoa, dtaInicio, dtaFim, numDiaEmissao, tipListarNaoFaturadosEmAtraso);

            //lancamentos com contrato
            var analiseComContrato = AnalisarFaturamentoContratos(codEmpresa, codPessoa, dtaInicio, dtaFim, numDiaEmissao, tipListarNaoFaturadosEmAtraso).ToList();

            var resultado = AgruparAnalisePorPessoa(analiseSemContrato, analiseComContrato).ToList();

            return resultado;
        }

        private static IEnumerable<ResultadoAnaliseCliente> AgruparAnalisePorPessoa(List<ResultadoAnaliseLancamentos> analiseSemContrato, List<ResultadoAnaliseContratos> analiseComContrato)
        {
            var codPessoasSemContrato = analiseSemContrato.Select(x => x.CodPessoa ?? 0).ToList();
            var codPessoasComContrato = analiseComContrato.Select(x => x.CodPessoa).ToList();

            var listaCodPessoas = codPessoasSemContrato.Concat(codPessoasComContrato).Distinct();

            foreach (var item in listaCodPessoas)
            {
                var lancamentos = analiseSemContrato.Where(x => x.CodPessoa == item);

                var contratos = analiseComContrato.Where(x => x.CodPessoa == item);

                yield return new ResultadoAnaliseCliente(contratos, lancamentos);
            }
        }

        public IEnumerable<ResultadoAnaliseContratos> AnalisarFaturamentoContratos(int codEmpresa, int? codPessoa, DateTime dtaInicio, DateTime? dtaFim, int numDiaEmissao = 0, bool tipListarNaoFaturadosEmAtraso = true)
        {
            var vlrValorHoraServicoParametro = _repositorioGenerico.GetSingleById<FT_PARAMETROS>(codEmpresa)?.VLR_HORA_SERVICO ?? 0m;

            var queryLancamentosComContrato = RetornarLancamentosComContrato(codEmpresa);

            queryLancamentosComContrato = queryLancamentosComContrato
                .Where((lancamento) => lancamento.COD_PESSOANavigation.PS_CONTRATOS.Any(y => (y.NUM_DIA_EMISSAO == numDiaEmissao || numDiaEmissao == 0)));

            if (codPessoa.HasValue)
                queryLancamentosComContrato = queryLancamentosComContrato.Where(l => l.COD_PESSOA == codPessoa.Value);

            var queryLancamentosComContratoNovo = LANCAMENTOS_FATURAMENTO.QueryToModel(queryLancamentosComContrato);

            var contratosFiltrados = _repositorioGenerico
                .Query<PS_CONTRATOS>().Where(c => c.COD_EMPRESA == codEmpresa)
                .Where(contrato => contrato.NUM_DIA_EMISSAO == numDiaEmissao || numDiaEmissao == 0)
                .Where(contrato => contrato.DTA_VIGENCIA_FINAL == null || (contrato.DTA_VIGENCIA_FINAL != null && contrato.DTA_VIGENCIA_FINAL >= contrato.DTA_ULTIMA_FATURA));

            if (codPessoa.HasValue)
            {
                contratosFiltrados = contratosFiltrados
                    .Where(contrato => contrato.COD_PESSOA == codPessoa);
            }

            var contratos = MapToContratos(codEmpresa, contratosFiltrados).ToList();

            var dataFaturasGeral = new List<DatasFaturamentoContratos>();
            foreach (var contrato in contratos)
            {
                if (!contrato.DTA_PROXIMA_FATURA_INICIAL.HasValue || !contrato.DTA_PROXIMA_FATURA_FINAL.HasValue)
                    throw new Exception($"Contrato nº {contrato.NUM_CONTRATO}, cliente {contrato.DES_PESSOA} não possui data de proxima fatura.");

                var dtaUltimaFatura = RetornarDtaUltimaFatura(contrato);
                var dtaProximaFatura = CalcularProximaEmissao(contrato.NUM_DIA_EMISSAO, dtaUltimaFatura, contrato.IND_RECORRENCIA);

                var datasFranquia = CalcularEmissaoContrato
                    (
                        contrato.NUM_DIA_EMISSAO, contrato.DTA_PROXIMA_FATURA_INICIAL.Value,
                        contrato.DTA_PROXIMA_FATURA_FINAL.Value, dtaFim,
                        contrato.IND_RECORRENCIA_FRANQUIA, contrato.NUM_DIA_VENCIMENTO,
                        contrato.IND_FIXADO ?? (int)IndicadorTipoConbranca.PosFixado, contrato.DTA_VIGENCIA_FINAL                        
                    );

                var dataFaturas = CalcularEmissaoContrato
                    (
                        contrato.NUM_DIA_EMISSAO, dtaUltimaFatura,
                        dtaProximaFatura.AddDays(-1), dtaFim,
                        contrato.IND_RECORRENCIA, contrato.NUM_DIA_VENCIMENTO, 
                        contrato.IND_FIXADO ?? (int)IndicadorTipoConbranca.PosFixado, contrato.DTA_VIGENCIA_FINAL
                    );

                if (tipListarNaoFaturadosEmAtraso == false)
                    datasFranquia = datasFranquia.Where(x => x.DtaEmissao >= dtaInicio && x.DtaEmissao <= dtaFim);

                if (contrato.DTA_VIGENCIA_FINAL != null)
                    dataFaturas = dataFaturas.Where(x => x.DtaConsultaInicial < contrato.DTA_VIGENCIA_FINAL.Value);

                dataFaturasGeral.Add(new DatasFaturamentoContratos()
                {
                    Contrato = contrato,
                    DataFaturas = dataFaturas.ToList(),
                    DataFranquias = datasFranquia.ToList()
                });
            }

            DateTime? maxDataFinal = null;
            if (dataFaturasGeral.Any(d => d.DataFaturas.Any()))
            {
                maxDataFinal = dataFaturasGeral.SelectMany(d => d.DataFaturas.Select(x => x.DtaConsultaFinal)).Max();
            }

            var analiseComContrato = new ConcurrentBag<ResultadoAnaliseContratos>();

            if (maxDataFinal != null)
            {
                var codigosProdutos = contratos.SelectMany(x => x.ITEMS).Select(i => i.COD_PRODUTO);
                var todosLancamentos = queryLancamentosComContratoNovo
                            .Where(x => codigosProdutos.Any(c => c == x.COD_PRODUTO)
                            && x.DTA_COBRANCA <= maxDataFinal).ToList();

                Parallel.ForEach(dataFaturasGeral, dataContratos =>
                {
                    var contrato = dataContratos.Contrato;

                    var arrCodigosProdutoContrato = contrato.ITEMS.Select(x => x.COD_PRODUTO);
                    var lancamentosDoContrato = todosLancamentos.Where(x =>
                        x.COD_PESSOA == contrato.COD_PESSOA
                        && arrCodigosProdutoContrato.Any(y => y == x.COD_PRODUTO));


                    Parallel.ForEach(dataContratos.DataFaturas, dataFatura =>
                    {
                        DatasPreCalculadasContrato dataAnalise = dataFatura;
                        var datasFranquia = dataContratos.DataFranquias;
                        var isPeriodoCobrancaFranquia = datasFranquia.Any(x => x.DtaEmissao == dataFatura.DtaEmissao);

                        if (isPeriodoCobrancaFranquia)
                        {
                            dataAnalise = datasFranquia
                                .FirstOrDefault(x => x.DtaEmissao == dataFatura.DtaEmissao);
                        }

                        var lancamentosAFaturar = lancamentosDoContrato.ToList();

                        //proxima primeira parcela: pega todos lancamentos até aquela data
                        if (dataAnalise.DtaConsultaInicial == contrato.DTA_PROXIMA_FATURA_INICIAL)
                        {
                            lancamentosAFaturar = lancamentosDoContrato
                                .Where(x => x.DTA_COBRANCA.Date <= dataAnalise.DtaConsultaFinal)
                                .Where(l => !l.ehFaturado).ToList();
                        }
                        else
                        {
                            lancamentosAFaturar = lancamentosDoContrato
                                .Where(x => x.DTA_COBRANCA.Date >= dataAnalise.DtaConsultaInicial)
                                .Where(x => x.DTA_COBRANCA.Date <= dataAnalise.DtaConsultaFinal)
                                .ToList();
                        }

                        var franquiaContrato = new BancoFranquia(contrato);
                        var resultadoLancamentos = RetornarLancamentoContratoProcessado(franquiaContrato, lancamentosAFaturar.ToList(), vlrValorHoraServicoParametro);

                        var resultadoAnaliseContrato = NovoResultadoContrato(contrato, resultadoLancamentos, isPeriodoCobrancaFranquia);

                        resultadoAnaliseContrato.BancoFranquia = franquiaContrato;
                        resultadoAnaliseContrato.DtaAnaliseInicial = dataAnalise.DtaConsultaInicial;
                        resultadoAnaliseContrato.DtaAnaliseFinal = dataAnalise.DtaConsultaFinal;
                        resultadoAnaliseContrato.DtaEmissao = dataAnalise.DtaEmissao;

                        if (contrato.IND_RECORRENCIA_FRANQUIA != (int)TipoRecorrenciaContrato.Mensal && !isPeriodoCobrancaFranquia)
                        {
                            var listaLancamentos = lancamentosDoContrato
                                .Where(l =>
                                    l.DTA_COBRANCA <= resultadoAnaliseContrato.DtaAnaliseFinal
                                    && !l.ehFaturado)
                                .ToList();

                            ProcessarLancamentosAteOPeriodo(resultadoAnaliseContrato, listaLancamentos);
                        }

                        analiseComContrato.Add(resultadoAnaliseContrato);
                    });
                });
            }

            return analiseComContrato;
        }

        private IQueryable<CONTRATO> MapToContratos(int codEmpresa, IQueryable<PS_CONTRATOS> contratosFiltrados)
        {
            var empresaPadrao = _empresasPadrao.EmpresasPadraoCollection(codEmpresa).Result;
            var empresaPadraoBancos = empresaPadrao[EmpresaPadrao.Bancos].CodEmpresaPadrao;

            var vlrValorHoraServicoParametro = _repositorioGenerico.GetSingleById<FT_PARAMETROS>(codEmpresa)?.VLR_HORA_SERVICO ?? 0m;

            return contratosFiltrados
                .Select(c => new CONTRATO
                {
                    IND_RECORRENCIA_FRANQUIA = c.IND_RECORRENCIA_FRANQUIA,
                    IND_RECORRENCIA = c.IND_RECORRENCIA,
                    DTA_VIGENCIA_INICIAL = c.DTA_VIGENCIA_INICIAL,
                    DTA_VIGENCIA_FINAL = c.DTA_VIGENCIA_FINAL,
                    COD_CONTRATO = c.COD_CONTRATO,
                    COD_CONVENIO_BANCARIO = c.COD_CONVENIO_BANCARIO,
                    COD_TIPO_PAGAMENTO = c.COD_TIPO_PAGAMENTO,
                    COD_TIPO_PAGAMENTO_PESSOA = c.COD_PESSOANavigation.COD_TIPO_PAGAMENTO,
                    DES_PESSOA = c.COD_PESSOANavigation.DES_PESSOA!,
                    DTA_PROXIMA_FATURA_FINAL = c.DTA_PROXIMA_FATURA_FINAL,
                    DTA_PROXIMA_FATURA_INICIAL = c.DTA_PROXIMA_FATURA_INICIAL,
                    DTA_ULTIMA_FATURA = c.DTA_ULTIMA_FATURA,
                    DTA_ULTIMO_REAJUSTE = c.PS_CONTRATOS_ITENS.Select(i => i.PS_CONTRATOS_REAJUSTES.Max(r => r.DTA_REAJUSTE)).FirstOrDefault(),
                    IND_REGRA_VENCIMENTO = c.IND_REGRA_VENCIMENTO ?? 0,
                    IND_TIPO_FRANQUIA = c.IND_TIPO_FRANQUIA,
                    NUM_CONTRATO = c.NUM_CONTRATO,
                    NUM_DIA_EMISSAO = c.NUM_DIA_EMISSAO,
                    QTD_FRANQUIA = c.QTD_FRANQUIA,
                    NUM_DIA_VENCIMENTO = c.NUM_DIA_VENCIMENTO,
                    TIP_AGRUPA_FATURA_CONTRATO = c.COD_PESSOANavigation.TIP_AGRUPA_FATURA_CONTRATO,
                    VLR_HORA_SERVICO_PARAMETRO = vlrValorHoraServicoParametro,
                    VLR_CONTRATO = c.VLR_CONTRATO,
                    COD_BANCO_PESSOA = c.COD_PESSOANavigation.COD_BANCO,
                    COD_PESSOA = c.COD_PESSOA,
                    DES_RAZAO_SOCIAL = c.COD_PESSOANavigation.DES_RAZAO_SOCIAL!,
                    IND_FIXADO = c.IND_FIXADO,
                    ITEMS = c.PS_CONTRATOS_ITENS.Select(i => new ITEM_CONTRATO()
                    {
                        COD_CONTRATO_ITENS = i.COD_CONTRATO_ITENS,
                        COD_PRODUTO = i.COD_PRODUTO,
                        DES_PRODUTO = i.COD_PRODUTONavigation.DES_PRODUTO,
                        DES_SERVICO_NOTA = i.DES_SERVICO_NOTA,
                        IND_TIPO_CONTRATO = i.IND_TIPO_CONTRATO,
                        QTD_FRANQUIA = i.QTD_FRANQUIA,
                        VLR_CONTRATO = i.VLR_CONTRATO
                    }).ToList(),
                });
        }

        private List<ResultadoAnaliseLancamentos> ConsultarLancamentosSemContratos(int codEmpresa, int? codPessoa, DateTime dtaInicio, DateTime? dtaFim, int numDiaEmissao, bool tipListarNaoFaturadosEmAtraso)
        {
            var vlrValorHoraServicoParametro = _repositorioGenerico.GetSingleById<FT_PARAMETROS>(codEmpresa)?.VLR_HORA_SERVICO ?? 0m;

            var queryLancamentosSemContrato = RetornarLancamentosSemContrato(codEmpresa)
                .Where(x => (x.DTA_COBRANCA.Day == numDiaEmissao || numDiaEmissao == 0)
                 && x.DTA_COBRANCA <= dtaFim);

            if (codPessoa.HasValue)
            {
                queryLancamentosSemContrato = queryLancamentosSemContrato.Where(l => l.COD_PESSOA == codPessoa.Value);
            }

            if (!tipListarNaoFaturadosEmAtraso)
            {
                queryLancamentosSemContrato = queryLancamentosSemContrato
                    .Where(x => x.DTA_COBRANCA <= dtaFim && x.DTA_COBRANCA >= dtaInicio);
            }

            var query = queryLancamentosSemContrato
                .Where(x => x.FT_FATURA_ITENS.Count == 0
                || x.FT_FATURA_ITENS.All(y => (y.COD_FATURANavigation.TIP_EXCLUIDO ?? false)));

            var lancamentos = LANCAMENTOS_FATURAMENTO.QueryToModel(query).ToList();

            return GerarLancamentosAvulsos(lancamentos, vlrValorHoraServicoParametro).ToList();
        }



        private ResultadoAnaliseContratos NovoResultadoContrato(CONTRATO contrato, List<ResultadoAnaliseLancamentos> listaLancamentosContrato, bool isPeriodoCobrancaFranquia)
        {

            var analiseContrato = new ResultadoAnaliseContratos();


            analiseContrato.CodPessoa = contrato.COD_PESSOA;
            analiseContrato.CodContrato = contrato.COD_CONTRATO;
            analiseContrato.Contrato = contrato;
            analiseContrato.TipAgrupa = contrato.TIP_AGRUPA_FATURA_CONTRATO ?? false;
            analiseContrato.DtaUltimoReajuste = retornarDataRealizadoUltimoReajuste(contrato);
            analiseContrato.TipPeriodoCobrancaFranquia = isPeriodoCobrancaFranquia;

            var lancamentosSemFranquia = listaLancamentosContrato
                .Where(l =>
                    l.TipCobrancaFaturamento
                    && !l.TipConsiderarFranquia
                )
                .ToList();

            if (!isPeriodoCobrancaFranquia)
                analiseContrato.ListaLancamentosNoPeriodo = listaLancamentosContrato
                    .Except(lancamentosSemFranquia)
                    .ToList();
            else
                analiseContrato.ListaLancamentos = analiseContrato.ListaLancamentos
                    .Union(listaLancamentosContrato)
                    .ToList();

            analiseContrato.ListaLancamentos = analiseContrato.ListaLancamentos.Union(lancamentosSemFranquia).ToList();

            analiseContrato.VlrTotal = analiseContrato.ListaLancamentos.Sum(x => x.VlrTotal);
            analiseContrato.VlrLancamento = analiseContrato.ListaLancamentos.Sum(x => x.VlrLancamento);
            analiseContrato.VlrDesconto = analiseContrato.ListaLancamentos.Sum(x => x.VlrDesconto);
            analiseContrato.TotalMinutosCobrados = analiseContrato.ListaLancamentos.Sum(x => x.TotalMinutosCobrados);
            analiseContrato.TotalMinutosTrabalhados = analiseContrato.ListaLancamentos.Sum(x => x.TotalMinutosTrabalhados);
            analiseContrato.TotalMinutosFaturados = analiseContrato.ListaLancamentos.Sum(x => x.TotalMinutosFaturados);
            analiseContrato.TotalFranquiaMinutos = RetornaQtdeTotalFranquiaPorTipo(contrato, TipoFranquiaContrato.Horas);
            analiseContrato.TotalFranquiaQuantidade = RetornaQtdeTotalFranquiaPorTipo(contrato, TipoFranquiaContrato.Quantidade);
            analiseContrato.ListaItensValorContrato = contrato.ITEMS.Where(x => x.IND_TIPO_CONTRATO == (int)TipoContrato.valorContrato).ToList();
            analiseContrato.AdicionarContratos(contrato);
            return analiseContrato;
        }

        private int RetornaQtdeTotalFranquiaPorTipo(CONTRATO contrato, TipoFranquiaContrato tipoFranquia)
        {
            var soma = contrato.IND_TIPO_FRANQUIA == (int)tipoFranquia
                ? contrato.QTD_FRANQUIA ?? 0
                : 0;

            soma += contrato.ITEMS
                    .Where(x => x.IND_TIPO_CONTRATO == (int)tipoFranquia)
                    .Sum(x => x.QTD_FRANQUIA) ?? 0;

            return soma;
        }

        private DateTime RetornarDtaUltimaFatura(CONTRATO contrato)
        {
            if (contrato.DTA_ULTIMA_FATURA != null)
                return contrato.DTA_ULTIMA_FATURA.Value;

            if (contrato.DTA_PROXIMA_FATURA_INICIAL != null)
                return contrato.DTA_PROXIMA_FATURA_INICIAL.Value;

            return contrato.DTA_VIGENCIA_INICIAL;
        }

        private DateTime? retornarDataRealizadoUltimoReajuste(CONTRATO contrato)
        {
            var dtaRealizadoUltimoReajuste = contrato.DTA_ULTIMO_REAJUSTE;

            return dtaRealizadoUltimoReajuste;
        }

        private void ProcessarLancamentosAteOPeriodo(ResultadoAnaliseContratos resultadoAnaliseContrato, List<LANCAMENTOS_FATURAMENTO> lancamentosDoContrato)
        {
            var bancoFranquia = new BancoFranquia(resultadoAnaliseContrato.Contrato);
            var vlrValorHoraServicoParametro = resultadoAnaliseContrato.Contrato.VLR_HORA_SERVICO_PARAMETRO;

            var resultado = RetornarLancamentoContratoProcessado(bancoFranquia, lancamentosDoContrato, vlrValorHoraServicoParametro);

            resultadoAnaliseContrato.ListaLancamentosAteOPeriodo = resultado;
            resultadoAnaliseContrato.BancoFranquia = bancoFranquia;
        }

        private IEnumerable<DatasPreCalculadasContrato> CalcularEmissaoContrato(
            int numDiaEmissao,
            DateTime dtaAnaliseInicial,
            DateTime dtaAnaliseFinal,
            DateTime? dtaLimiteConsulta,
            int numMesesRecorrencia,
            int diaVencimento,
            int indFixado,
            DateTime? dtaVigenciaFinal = null)
        {
            if (dtaVigenciaFinal.HasValue && dtaVigenciaFinal < dtaLimiteConsulta)
            {
                dtaLimiteConsulta = dtaVigenciaFinal.Value;
            }

            var usarMesCorrente = indFixado == (int)IndicadorTipoConbranca.PreFixado && numDiaEmissao >= DateTime.Now.Day;

            // Cálculo inicial da emissão
            var dtaEmissao = CalcularProximaEmissao(numDiaEmissao, dtaAnaliseInicial, numMesesRecorrencia, false);
            if (usarMesCorrente)
                dtaEmissao = CalcularProximaEmissao(numDiaEmissao, dtaAnaliseInicial, numMesesRecorrencia, true);

            var resultado = new List<DatasPreCalculadasContrato>
            {
                new DatasPreCalculadasContrato(dtaEmissao, dtaAnaliseInicial, dtaAnaliseFinal)
            };

            //Loop para gerar as recorências
            while (dtaEmissao < dtaLimiteConsulta)
            {
                var dtaConsultaInicio = dtaEmissao;

                // Se for necessário usar o mês corrente ou dia atual, recalcula a data de início
                if (usarMesCorrente)
                    dtaConsultaInicio = CalcularProximaEmissao(numDiaEmissao, dtaConsultaInicio, numMesesRecorrencia);

                var dtaConsultaFinal = CalculaProximaRecorrencia(numDiaEmissao, dtaConsultaInicio, numMesesRecorrencia);

                // Calcula a próxima emissão
                dtaEmissao = CalcularProximaEmissao(numDiaEmissao, dtaEmissao, numMesesRecorrencia);

                if (EhMesGeracao(dtaConsultaInicio, numMesesRecorrencia, dtaEmissao) && dtaEmissao < dtaLimiteConsulta)
                {
                    resultado.Add(new DatasPreCalculadasContrato(dtaEmissao, dtaConsultaInicio, dtaConsultaFinal));
                }
            }

            return resultado;
        }

        public DateTime CalcularProximaEmissao(int diaEmissao, DateTime dtaCalculo, int numRecorrencia, bool usarMesCorrente = false)
        {
            var proximaData = dtaCalculo.AddMonths(numRecorrencia);
            var ano = proximaData.Year;
            var mes = usarMesCorrente ? proximaData.AddMonths(-1).Month : proximaData.Month;
            var maximoDiasNoMes = DateTime.DaysInMonth(ano, mes);

            diaEmissao = diaEmissao > maximoDiasNoMes ? maximoDiasNoMes : diaEmissao;

            return new DateTime(ano, mes, diaEmissao);
        }

        public DateTime CalculaProximaRecorrencia(int diaEmissao, DateTime dtaCalculo, int numRecorrencia)
        {
            return CalcularProximaEmissao(diaEmissao, dtaCalculo, numRecorrencia).AddDays(-1);
        }

        private bool EhMesGeracao(DateTime dtaInicio, int numMesesRecorrencia, DateTime dtaConsultaFinal)
        {
            return (dtaConsultaFinal.Month - dtaInicio.Month) % numMesesRecorrencia == 0;
        }

        public IEnumerable<ResultadoAnaliseLancamentos> GerarLancamentosAvulsos(List<LANCAMENTOS_FATURAMENTO> lancamentos, decimal vlrHoraServicoParametro)
        {
            var listaResultado = new ConcurrentBag<ResultadoAnaliseLancamentos>();
            Parallel.ForEach(lancamentos, lancamento =>
            {

                var resultadoAvulso = new ResultadoAnaliseLancamentos(lancamento);

                if (lancamento.TIPO_COBRANCA_FATURAMENTO == false)
                {
                    resultadoAvulso.TotalMinutosFaturados = 0;
                    resultadoAvulso.TotalMinutosCobrados = 0;
                    listaResultado.Add(resultadoAvulso);
                    return;
                }

                var vlrLancamento = 0.00m;
                if (lancamento.IND_TIPO_LANCAMENTO == (int)TipoLancamento.Hora)
                {
                    vlrLancamento = RetornaValorLancamento(vlrHoraServicoParametro, lancamento);
                    vlrLancamento = CalculaValorMinutos(vlrLancamento, resultadoAvulso.TotalMinutosFaturados);
                }

                resultadoAvulso.VlrDesconto = lancamento.VLR_DESCONTO ?? 0;

                if (lancamento.IND_TIPO_LANCAMENTO == (int)TipoLancamento.Valor && lancamento.TIPO_COBRANCA_FATURAMENTO.HasValue)
                {
                    vlrLancamento = lancamento.VLR_LANCAMENTO ?? 0;
                }

                resultadoAvulso.VlrLancamento = lancamento.VLR_LANCAMENTO ?? 0;
                resultadoAvulso.VlrTotal = vlrLancamento;

                if (resultadoAvulso.VlrTotal == 0)
                    resultadoAvulso.TipErro = true;

                listaResultado.Add(resultadoAvulso);
            });

            return listaResultado;

        }

        internal List<ResultadoAnaliseLancamentos> RetornarLancamentoContratoProcessado(BancoFranquia franquiaContrato, List<LANCAMENTOS_FATURAMENTO> lancamentos, decimal vlrHoraParametro)
        {
            var listaResultado = new List<ResultadoAnaliseLancamentos>();
            foreach (var lancamento in lancamentos)
            {
                var resultadoLancamento = new ResultadoAnaliseLancamentos();
                listaResultado.Add(resultadoLancamento);

                var hmsLancamento = lancamento.HMS_LANCAMENTO ?? 0;
                if (lancamento.HMS_AJUSTADA > 0)
                    hmsLancamento = lancamento.HMS_AJUSTADA ?? 0;

                resultadoLancamento.CodLancamento = lancamento.COD_LANCAMENTO;
                resultadoLancamento.CodLancamento = lancamento.COD_LANCAMENTO;
                resultadoLancamento.CodProduto = lancamento.COD_PRODUTO;
                resultadoLancamento.DesProduto = lancamento.DES_PRODUTO;
                resultadoLancamento.DtaCobranca = lancamento.DTA_COBRANCA;
                resultadoLancamento.TotalMinutosTrabalhados = lancamento.HMS_LANCAMENTO ?? 0;
                resultadoLancamento.TotalMinutosCobrados = hmsLancamento;
                resultadoLancamento.VlrDesconto = lancamento.VLR_DESCONTO ?? 0;
                resultadoLancamento.VlrLancamento = lancamento.VLR_LANCAMENTO ?? 0;
                resultadoLancamento.VlrTotal = (lancamento.VLR_LANCAMENTO - (lancamento.VLR_DESCONTO ?? 0)) ?? 0;
                resultadoLancamento.Lancamento = lancamento;
                resultadoLancamento.TipCobrancaFaturamento = lancamento.TIPO_COBRANCA_FATURAMENTO.GetValueOrDefault();
                resultadoLancamento.TipConsiderarFranquia = lancamento.TIP_CONSIDERAR_FRANQUIA;

                var itemContrato = franquiaContrato
                    .ProdutosFranquias
                    .FirstOrDefault(x => x.ItemContrato.COD_PRODUTO == lancamento.COD_PRODUTO)
                    ?.ItemContrato;

                resultadoLancamento.CodItemContrato = itemContrato?.COD_CONTRATO_ITENS;

                //verificar se entra aqui quando item já foi faturado.
                if (lancamento.ehFaturado)
                {
                    resultadoLancamento.TipFaturado = true;
                    resultadoLancamento.TotalMinutosFaturados = hmsLancamento;

                    continue;
                }

                if (lancamento.IND_TIPO_LANCAMENTO == (int)TipoLancamento.Valor && lancamento.TIPO_COBRANCA_FATURAMENTO == true)
                {

                    resultadoLancamento.VlrTotal = 0.00m;
                    resultadoLancamento.VlrTotal = lancamento.VLR_LANCAMENTO ?? 0;
                    continue;
                }
                if (lancamento.IND_TIPO_LANCAMENTO == (int)TipoLancamento.Valor)
                {
                    resultadoLancamento.VlrNaoConsiderarFaturamento = lancamento.VLR_LANCAMENTO ?? 0;
                    resultadoLancamento.VlrTotal = 0.00m;
                    continue;
                }

                //marcado como cobrar
                if (lancamento.TIPO_COBRANCA_FATURAMENTO == false)
                {
                    resultadoLancamento.TotalMinutosCobrados -= hmsLancamento;
                    continue;
                }

                //franquia
                var tipoFranquiaContratoCabecalho = (TipoFranquiaContrato)(franquiaContrato.Contrato.IND_TIPO_FRANQUIA ?? 0);

                if (tipoFranquiaContratoCabecalho == TipoFranquiaContrato.Ilimitada)
                    continue;

                //escolha se franquia é do cabecalho ou item
                ItemBancoFranquia bancoFranquia = null;

                if (tipoFranquiaContratoCabecalho == TipoFranquiaContrato.SemFranquia)
                {
                    bancoFranquia = franquiaContrato.ProdutosFranquias
                        .FirstOrDefault(x => x.ItemContrato.COD_PRODUTO == lancamento.COD_PRODUTO
                        && x.ItemContrato.IND_TIPO_CONTRATO != (int)TipoFranquiaContrato.ValorFixo)!;
                }
                else
                {
                    bancoFranquia = franquiaContrato.ProdutosFranquias
                        .FirstOrDefault(x => x.ItemContrato.COD_PRODUTO == lancamento.COD_PRODUTO
                        && x.ItemContrato.IND_TIPO_CONTRATO == (int)tipoFranquiaContratoCabecalho)!;

                    if (bancoFranquia == null)
                    {
                        bancoFranquia = franquiaContrato.ProdutosFranquias
                        .FirstOrDefault(x => x.ItemContrato.COD_PRODUTO == lancamento.COD_PRODUTO)!;
                    }

                }

                decimal vlrProdutoNoContrato = RetornaValorLancamento(vlrHoraParametro, lancamento, bancoFranquia);

                //nao encontrou franquia
                if (bancoFranquia == null)
                {
                    resultadoLancamento.TotalMinutosFaturados = hmsLancamento;
                    resultadoLancamento.VlrTotal = CalculaValorMinutos(vlrProdutoNoContrato, resultadoLancamento.TotalMinutosCobrados);

                    continue;
                }

                if ((lancamento.TIP_CONSIDERAR_FRANQUIA) == false)
                {
                    resultadoLancamento.TotalMinutosFaturados = hmsLancamento;
                    resultadoLancamento.VlrTotal = CalculaValorMinutos(vlrProdutoNoContrato, resultadoLancamento.TotalMinutosCobrados);

                    continue;
                }


                if (bancoFranquia.ItemContrato.IND_TIPO_CONTRATO == (int)TipoFranquiaContrato.Ilimitada)
                    continue;

                if (vlrProdutoNoContrato == 0)
                    resultadoLancamento.TipErro = true;

                var tipoFranquiaProduto = (TipoFranquiaContrato)bancoFranquia.ItemContrato.IND_TIPO_CONTRATO;

                var qtdLancamento = hmsLancamento;
                if (tipoFranquiaProduto == TipoFranquiaContrato.Quantidade)
                    qtdLancamento = 1;

                var qtdRestante = 0;
                bancoFranquia.QtdRestante -= qtdLancamento;
                if (bancoFranquia.QtdRestante < 0)
                {
                    qtdRestante = Math.Abs(bancoFranquia.QtdRestante);
                    bancoFranquia.QtdRestante = 0;
                }

                if (tipoFranquiaContratoCabecalho == TipoFranquiaContrato.Quantidade && qtdRestante > 0)
                    qtdRestante = 1;

                franquiaContrato.QtdRestante -= qtdRestante;
                qtdRestante = 0;
                if (franquiaContrato.QtdRestante < 0)
                {
                    qtdRestante = Math.Abs(franquiaContrato.QtdRestante);
                    franquiaContrato.QtdRestante = 0;
                }


                if (tipoFranquiaProduto == TipoFranquiaContrato.Quantidade)
                {
                    resultadoLancamento.TotalMinutosFaturados = qtdRestante == 0 ? 0 : hmsLancamento;
                    resultadoLancamento.VlrTotal = qtdRestante * bancoFranquia.ItemContrato.VLR_CONTRATO ?? 0;
                    continue;
                }

                resultadoLancamento.TotalMinutosFaturados = qtdRestante;
                resultadoLancamento.VlrTotal = CalculaValorMinutos(vlrProdutoNoContrato, qtdRestante);
            }

            return listaResultado;
        }

        private static decimal RetornaValorLancamento(decimal vlrHoraParametro, LANCAMENTOS_FATURAMENTO lancamento, ItemBancoFranquia bancoFranquia = null)
        {
            if (lancamento.VLR_HORA != 0)
                return lancamento.VLR_HORA;

            if (bancoFranquia != null)
            {
                var vlrPrecoHoraContrato = 0m;
                if (bancoFranquia.ItemContrato.IND_TIPO_CONTRATO == (int)TipoFranquiaContrato.Horas)
                    vlrPrecoHoraContrato = bancoFranquia.ItemContrato.VLR_CONTRATO ?? 0m;

                if (vlrPrecoHoraContrato != 0)
                    return vlrPrecoHoraContrato;
            }

            var vlrPrecoVendaProduto = lancamento.VLR_HORA_PRECO_PRODUTO;
            if (vlrPrecoVendaProduto != 0)
                return vlrPrecoVendaProduto;


            return vlrHoraParametro;
        }


        public decimal CalculaValorMinutos(decimal valor, int numMinutos)
        {
            return (valor / 60) * numMinutos;
        }


        public IQueryable<PS_LANCAMENTOS> RetornarLancamentosSemContrato(int codEmpresa)
        {
            var queryLancamentos = _repositorioGenerico.Query<PS_LANCAMENTOS>().Where(x => x.COD_EMPRESA == codEmpresa);
            var lancamentoComContrato = RetornarLancamentosComContrato(codEmpresa);

            var lancamentosSemContrato = queryLancamentos
                .Where(x => !lancamentoComContrato.Any(lc => lc.COD_LANCAMENTO == x.COD_LANCAMENTO));




            return lancamentosSemContrato;
        }

        public IQueryable<PS_LANCAMENTOS> RetornarLancamentosComContrato(int codEmpresa)
        {
            var queryLancamentosPessoa = _repositorioGenerico.Query<PS_LANCAMENTOS>().Where(x => x.COD_EMPRESA == codEmpresa);

            var queryContratos = _repositorioGenerico
                .Query<PS_CONTRATOS>()
                .Where(x => x.COD_EMPRESA == codEmpresa);

            var queryItensContrato = queryContratos
                .SelectMany(x => x.PS_CONTRATOS_ITENS)
                .Distinct();

            return queryLancamentosPessoa
                    .Where
                    (
                        lancamento => queryItensContrato.Any
                        (
                            itemContrato => itemContrato.COD_PRODUTO == lancamento.COD_PRODUTO
                            && itemContrato.COD_CONTRATONavigation.DTA_VIGENCIA_INICIAL <= lancamento.DTA_COBRANCA
                            &&
                            (
                                itemContrato.COD_CONTRATONavigation.DTA_VIGENCIA_FINAL == null
                                || itemContrato.COD_CONTRATONavigation.DTA_VIGENCIA_FINAL >= lancamento.DTA_COBRANCA
                            )
                            &&
                            (
                                lancamento.PS_LANCAMENTOS_VENCIMENTO.Count == 0
                                || lancamento.DTA_LANCAMENTO.Value.Day == itemContrato.COD_CONTRATONavigation.NUM_DIA_VENCIMENTO
                            )
                        )
                    );
        }


    }
}

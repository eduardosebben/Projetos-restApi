using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.DRE.Models;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Relatorios.Aplication.Inventario.Services;

namespace Relatorios.Aplication.DRE.Services
{
    public interface IServicoRelatorioDRE
    {
        Task<RetornoDRE> RetornarRelatorioDRE(ConfiguradorRelatorioDREDto model);
        Task<RetornoDRE> RetornarValorContaMercadoriaVendida(ConfiguradorRelatorioDREDto model);
    }

    public class ServicoRelatorioDRE : IServicoRelatorioDRE
    {
        private readonly IErpRepositorioGenerico _repositorioErp;
        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;
        private readonly IServicoRelatorioInventario _servicoRelatorioInventario;

        public ServicoRelatorioDRE(
            IErpRepositorioGenerico repositorioErp,
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao,
            IServicoRelatorioInventario servicoRelatorioInventario)
        {
            _repositorioErp = repositorioErp;
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
            _servicoRelatorioInventario = servicoRelatorioInventario;
        }

        public async Task<RetornoDRE> RetornarRelatorioDRE(ConfiguradorRelatorioDREDto filtros)
        {
            if (!filtros.dtaMesAno.HasValue)
                throw new ArgumentException("Campo obrigatório ", nameof(filtros.dtaMesAno));

            var data = new DateTime(filtros.dtaMesAno.Value.Year, filtros.dtaMesAno.Value.Month, 1);

            var empresasPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(filtros.dadosAcessoModelDRE.CodigoEmpresa);
            var empresaPadraoOpFiscal = empresasPadrao[EmpresaPadrao.OperacaoFiscal].CodEmpresaPadrao;
            var empresaPadraoContaContabil = empresasPadrao[EmpresaPadrao.ContaContabil].CodEmpresaPadrao;
            var empresaPadraoContaDRE = empresasPadrao[EmpresaPadrao.ContaDRE].CodEmpresaPadrao;
            var empresaPadraoProduto = empresasPadrao[EmpresaPadrao.Produtos].CodEmpresaPadrao;
            var empresaPadraoProdutoComposicao = empresasPadrao[EmpresaPadrao.ProdutoComposicao].CodEmpresaPadrao;

            var queryContasContabeis = _repositorioErp.Query<GE_CONTAS_CONTABEIS>().Where(x => x.COD_EMPRESA == empresaPadraoContaContabil && 
                                                                                          x.COD_ORGANIZACAO == filtros.dadosAcessoModelDRE.CodigoOrganizacao);
            var queryPessoas = _repositorioErp.Query<PS_PESSOAS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa &&
                                                                         x.COD_ORGANIZACAO == filtros.dadosAcessoModelDRE.CodigoOrganizacao);
            var queryNotasSaida = _repositorioErp.Query<FT_NOTAS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa
                                                                          && x.DTA_EMISSAO >= data
                                                                          && x.DTA_EMISSAO <= filtros.dtaMesAno
                                                                          && x.DTA_AUTORIZACAO.HasValue
                                                                          && x.IND_SITUACAO != 2
                                                                          && x.IND_SITUACAO != 3
                                                                          && (x.IND_TIPO_NOTA == 2 
                                                                          || x.IND_TIPO_NOTA == 3
                                                                          || x.IND_TIPO_NOTA == 1))
                                                                   .OrderBy(x => x.NUM_NOTA)
                                                                   .Include(x => x.COD_PESSOANavigation)
                                                                   .Include(x => x.COD_OPERACAO_FISCALNavigation)
                                                                   .Include(x => x.FT_NOTAS_ITENS);

            var queryNotasEntrada = _repositorioErp.Query<CE_NOTAS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa
                                                                            && x.DTA_ENTRADA.Value.Month == filtros.dtaMesAno.Value.Month
                                                                            && x.DTA_ENTRADA.Value.Year == filtros.dtaMesAno.Value.Year)
                                                                     .Include(x => x.CE_NOTAS_ITENS)
                                                                     .Include(x => x.CE_NOTAS_RELACAO_SAIDAS)
                                                                     .Include(x => x.COD_PESSOANavigation)
                                                                     .Include(x => x.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADANavigation)
                                                                     .Include(x => x.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADA_RELACIONADANavigation)
                                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation);

            var queryItensOrdem = _repositorioErp.Query<CO_ORDENS_ITENS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa);
            //.Include();

            var queryTitulosReceber = _repositorioErp.Query<CR_TITULOS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa
                                                                                && x.DTA_VENCIMENTO.Value.Month == filtros.dtaMesAno.Value.Month
                                                                                && x.DTA_VENCIMENTO.Value.Year == filtros.dtaMesAno.Value.Year
                                                                                && (x.COD_NOTA == 0
                                                                                || x.COD_NOTA == null))
                                                                         .Include(x => x.COD_CONTA_CONTABILNavigation)
                                                                         .Include(x => x.COD_PESSOANavigation)
                                                                         .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation)
                                                                         .Include(x => x.COD_CONTA_CONTABILNavigation.COD_DRENavigation);

            var queryTitulosPagar = _repositorioErp.Query<CP_TITULOS>().Where(x => x.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa
                                                                                       && x.DTA_VENCIMENTO.Month == filtros.dtaMesAno.Value.Month
                                                                                       && x.DTA_VENCIMENTO.Year == filtros.dtaMesAno.Value.Year
                                                                                       && (x.COD_NOTA == 0
                                                                                       || x.COD_NOTA == null))
                                                                        .Include(x => x.COD_CONTA_CONTABILNavigation)
                                                                        .Include(x => x.COD_PESSOANavigation)
                                                                        .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation)
                                                                        .Include(x => x.COD_CONTA_CONTABILNavigation.COD_DRENavigation);

            var queryContasDRE = _repositorioErp.Query<GE_DRE>().Where(x => x.COD_EMPRESA == empresaPadraoContaDRE && 
                                                                       x.COD_CONTA_DRE != 1)
                                                                .Include(x => x.GE_CONTAS_CONTABEIS)
                                                                .Include(x => x.COD_CONTA_DRENavigation);

            var queryItensNotaEntrada = queryNotasEntrada.SelectMany(x => x.CE_NOTAS_ITENS);

            var codConta = 0;
            decimal vlrConta = 0;
            string desConta = "";
            var Contas = new List<Conta>();
            var ContasPai = new List<ContaPai>();
            var notasTitulos = new List<NotaTitulo>();

            queryItensNotaEntrada = queryItensNotaEntrada.Include(x => x.COD_CONTA_CONTABILNavigation)
                                                         .Include(x => x.COD_NOTANavigation)
                                                         .Include(x => x.COD_OPERACAO_FISCALNavigation)
                                                         .Include(x => x.COD_PRODUTONavigation)
                                                         .Include(x => x.COD_NOTANavigation.COD_PESSOANavigation)
                                                         .Include(x => x.COD_CONTA_CONTABILNavigation.COD_DRENavigation)
                                                         .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation)
                                                         .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation.COD_DRENavigation);

            queryItensNotaEntrada
            .Where(x => x.COD_CONTA_CONTABILNavigation.COD_DRE != 0 && x.COD_CONTA_CONTABILNavigation.COD_DRE != null)
            .ToList()
            .ForEach(x =>
            {
                if (codConta == 0)
                {
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                }
                if (x.COD_CONTA_CONTABILNavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.HasValue &&
                    codConta == x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.Value)
                {
                    vlrConta += x.VLR_TOTAL.Value;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desFornecedor = x.COD_NOTANavigation.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Nota Entrada/Fornecedor: " + x.COD_NOTANavigation.NUM_NOTA + "/" + desFornecedor +
                                               " Produto: " + x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA + " Op. Fiscal: " +
                                               x.COD_OPERACAO_FISCAL + " - " + x.COD_OPERACAO_FISCALNavigation?.DES_OPERACAO_FISCAL + " Valor: " + x.VLR_TOTAL.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
                else
                {
                    var Conta = new Conta(codConta, vlrConta, desConta);
                    Conta.notaTitulos = new List<NotaTitulo>(notasTitulos);
                    if (Contas.Where(y => y.codConta == codConta).Any())
                        Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                    else
                        Contas.Add(Conta);
                    notasTitulos.Clear();

                    var contaDRE = queryContasDRE.Where(y => y.COD_CONTA_DRE == codConta).FirstOrDefault();
                    if (contaDRE.COD_DRE_PAI.HasValue && contaDRE.COD_DRE_PAI != 0)
                    {
                        VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                    }

                    vlrConta = x.VLR_TOTAL.Value;
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desFornecedor = x.COD_NOTANavigation.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Nota Entrada/Fornecedor: " + x.COD_NOTANavigation.NUM_NOTA + "/" + desFornecedor +
                                               " Produto: " + x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA + " Op. Fiscal: " + x.COD_OPERACAO_FISCAL + " - " +
                                               x.COD_OPERACAO_FISCALNavigation?.DES_OPERACAO_FISCAL + " Valor: " + x.VLR_TOTAL.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
            });
            if (codConta != 0)
            {
                var ContaItensEntrada = new Conta(codConta, vlrConta, desConta);
                ContaItensEntrada.notaTitulos = new List<NotaTitulo>(notasTitulos);
                if (Contas.Where(y => y.codConta == codConta).Any())
                    Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                else
                    Contas.Add(ContaItensEntrada);
                notasTitulos.Clear();
                var contaDRE = queryContasDRE.Where(x => x.COD_CONTA_DRE == codConta).FirstOrDefault();
                if (contaDRE.COD_CONTA_DRE != 0 &&
                    contaDRE.COD_DRE_PAI.HasValue)
                {
                    VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                }
            }

            var queryItensNotaSaida = queryNotasSaida.SelectMany(x => x.FT_NOTAS_ITENS);

            queryItensNotaSaida = queryItensNotaSaida.Include(x => x.COD_CONTA_CONTABILNavigation)
                                                     .Include(x => x.COD_CONTA_CONTABILNavigation.COD_DRENavigation)
                                                     .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation)
                                                     .Include(x => x.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation.COD_DRENavigation)
                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation)
                                                     .Include(x => x.COD_NOTANavigation)
                                                     .Include(x => x.COD_PRODUTONavigation)
                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation.COD_CONTA_CONTABILNavigation.COD_DRENavigation)
                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation.COD_CONTA_CONTABILNavigation)
                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation.COD_CONTA_CONTABILNavigation.COD_CONTA_CONTABIL_PAINavigation)
                                                     .Include(x => x.COD_OPERACAO_FISCALNavigation.COD_CONTA_CONTABILNavigation.COD_DRENavigation);
            codConta = 0;
            vlrConta = 0;
            notasTitulos.Clear();
            queryItensNotaSaida
            .Where(x => x.COD_CONTA_CONTABILNavigation.COD_DRE != 0 &&
                   x.COD_CONTA_CONTABILNavigation.COD_DRE != null &&
                   x.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true)
            .ToList()
            .ForEach(x =>
            {
                if (codConta == 0)
                {
                    codConta = x.COD_CONTA_CONTABILNavigation?.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation?.COD_DRENavigation?.DES_DRE;
                }
                if (x.COD_CONTA_CONTABILNavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.HasValue &&
                    codConta == x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.Value)
                {
                    var vlrMercadoria = x.VLR_MERCADORIA ?? 0;
                    var vlrDesconto = x.VLR_DESCONTO ?? 0;

                    vlrConta += vlrMercadoria - vlrDesconto; 

                    if (filtros.IndRazaoContas)
                    {
                        var vlrTotalAnalitico = vlrMercadoria - vlrDesconto;
                        var notaTitulo = new NotaTitulo();
                        notaTitulo.Descricao = "Nota Saída: " + x.COD_NOTANavigation.NUM_NOTA + " Produto: " + x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA +
                                               " Op. Fiscal: " + x.COD_OPERACAO_FISCAL + " - " + x.COD_OPERACAO_FISCALNavigation.DES_OPERACAO_FISCAL + " Valor: " + vlrTotalAnalitico;
                        notasTitulos.Add(notaTitulo);
                    }
                }
                else
                {
                    var Conta = new Conta(codConta, vlrConta, desConta);
                    Conta.notaTitulos = new List<NotaTitulo>(notasTitulos);
                    if (Contas.Where(y => y.codConta == codConta).Any())
                        Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                    else
                        Contas.Add(Conta);
                    notasTitulos.Clear();
                    var contaDRE = queryContasDRE.Where(y => y.COD_CONTA_DRE == codConta).FirstOrDefault();
                    if (contaDRE.COD_DRE_PAI.HasValue && contaDRE.COD_DRE_PAI != 0)
                    {
                        VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                    }


                    var vlrMercadoria = x.VLR_MERCADORIA ?? 0;
                    var vlrDesconto = x.VLR_DESCONTO ?? 0;

                    vlrConta = vlrMercadoria  - vlrDesconto;
                    codConta = x.COD_CONTA_CONTABILNavigation?.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation?.COD_DRENavigation?.DES_DRE;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        notaTitulo.Descricao = "Nota Saída: " + x.COD_NOTANavigation.NUM_NOTA + " Produto: " + x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA +
                                               " Op. Fiscal: " + x.COD_OPERACAO_FISCAL + " - " + x.COD_OPERACAO_FISCALNavigation.DES_OPERACAO_FISCAL + " Valor: " + vlrConta;
                        notasTitulos.Add(notaTitulo);
                    }
                }
            });
            if (codConta != 0)
            {
                var ContaItensSaida = new Conta(codConta, vlrConta, desConta);
                ContaItensSaida.notaTitulos = new List<NotaTitulo>(notasTitulos);
                if (Contas.Where(y => y.codConta == codConta).Any())
                    Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                else
                    Contas.Add(ContaItensSaida);
                notasTitulos.Clear();
                var contaDRE = queryContasDRE.Where(x => x.COD_CONTA_DRE == codConta).FirstOrDefault();
                if (contaDRE.COD_CONTA_DRE != 0 &&
                    contaDRE.COD_DRE_PAI.HasValue)
                {
                    VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                }
            }

            codConta = 0;
            vlrConta = 0;
            notasTitulos.Clear();
            queryTitulosPagar
            .Where(x => x.COD_CONTA_CONTABILNavigation.COD_DRE.HasValue)
            .ToList()
            .ForEach(x =>
            {
                if (codConta == 0)
                {
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                }
                if (x.COD_CONTA_CONTABILNavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.HasValue &&
                    codConta == x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE)
                {
                    vlrConta += x.VLR_TITULO.Value;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desPessoa = x.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Título Pagar/Fornecedor: " + x.NUM_TITULO + "/" + desPessoa + " Valor: " + x.VLR_TITULO.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
                else
                {
                    var Conta = new Conta(codConta, vlrConta, desConta);
                    Conta.notaTitulos = new List<NotaTitulo>(notasTitulos);
                    if (Contas.Where(y => y.codConta == codConta).Any())
                        Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                    else
                        Contas.Add(Conta);
                    notasTitulos.Clear();
                    var contaDRE = queryContasDRE.Where(y => y.COD_CONTA_DRE == codConta).FirstOrDefault();
                    if (contaDRE.COD_DRE_PAI.HasValue && contaDRE.COD_DRE_PAI != 0)
                    {
                        VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                    }

                    vlrConta = x.VLR_TITULO.Value;
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desPessoa = x.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Título Pagar/Fornecedor: " + x.NUM_TITULO + "/" + desPessoa + " Valor: " + x.VLR_TITULO.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
            });
            if (codConta != 0)
            {
                var ContaTituloPagar = new Conta(codConta, vlrConta, desConta);
                ContaTituloPagar.notaTitulos = new List<NotaTitulo>(notasTitulos);
                if (Contas.Where(y => y.codConta == codConta).Any())
                    Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                else
                    Contas.Add(ContaTituloPagar);
                notasTitulos.Clear();
                var contaDRE = queryContasDRE.Where(x => x.COD_CONTA_DRE == codConta).FirstOrDefault();
                if (contaDRE.COD_CONTA_DRE != 0 &&
                    contaDRE.COD_DRE_PAI.HasValue)
                {
                    VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                }
            }

            codConta = 0;
            vlrConta = 0;
            notasTitulos.Clear();
            queryTitulosReceber
            .Where(x => x.COD_CONTA_CONTABILNavigation.COD_DRE.HasValue)
            .ToList()
            .ForEach(x =>
            {
                if (codConta == 0)
                {
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                }
                if (x.COD_CONTA_CONTABILNavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation != null &&
                    x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.HasValue &&
                    codConta == x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE.Value)
                {
                    vlrConta += x.VLR_TITULO.Value;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desPessoa = x.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Título Receber/Parcela - Cliente: " + x.NUM_TITULO + "/" + x.NUM_PARCELA + " - " + desPessoa + " Valor: " + x.VLR_TITULO.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
                else
                {
                    var Conta = new Conta(codConta, vlrConta, desConta);
                    Conta.notaTitulos = new List<NotaTitulo>(notasTitulos);
                    if (Contas.Where(y => y.codConta == codConta).Any())
                        Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                    else
                        Contas.Add(Conta);
                    notasTitulos.Clear();
                    var contaDRE = queryContasDRE.Where(y => y.COD_CONTA_DRE == codConta).FirstOrDefault();
                    if (contaDRE.COD_DRE_PAI.HasValue && contaDRE.COD_DRE_PAI != 0)
                    {
                        VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                    }

                    vlrConta = x.VLR_TITULO.Value;
                    codConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation.COD_CONTA_DRE ?? 0;
                    desConta = x.COD_CONTA_CONTABILNavigation.COD_DRENavigation?.DES_DRE;
                    if (filtros.IndRazaoContas)
                    {
                        var notaTitulo = new NotaTitulo();
                        var desPessoa = x.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? x.COD_PESSOANavigation.DES_PESSOA;
                        notaTitulo.Descricao = "Título Receber/Parcela - Cliente: " + x.NUM_TITULO + "/" + x.NUM_PARCELA + " - " + desPessoa + " Valor: " + x.VLR_TITULO.Value;
                        notasTitulos.Add(notaTitulo);
                    }
                }
            });
            if (codConta != 0)
            {
                var ContaTituloReceber = new Conta(codConta, vlrConta, desConta);
                ContaTituloReceber.notaTitulos = new List<NotaTitulo>(notasTitulos);
                if (Contas.Where(y => y.codConta == codConta).Any())
                    Contas.Where(y => y.codConta == codConta).ToList().ForEach(y => y.valorTotal += vlrConta);
                else
                    Contas.Add(ContaTituloReceber);
                notasTitulos.Clear();
                var contaDRE = queryContasDRE.Where(x => x.COD_CONTA_DRE == codConta).FirstOrDefault();
                if (contaDRE.COD_CONTA_DRE != 0 &&
                    contaDRE.COD_DRE_PAI.HasValue)
                {
                    VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta, ContasPai);
                }

            }
            notasTitulos.Clear();
            var contasIndDRE = new ContasIndDRE();
            foreach (var item in queryContasDRE)
            {
                var contaIndDRE = new ContaIndDRE();
                contaIndDRE.codConta = item.COD_CONTA_DRE.Value;
                switch (item.DES_DRE.ToUpper())
                {
                    case "PIS":
                        contaIndDRE.indDRE = (int)ContaContabil.indPis;
                        break;
                    case "COFINS":
                        contaIndDRE.indDRE = (int)ContaContabil.indCofins;
                        break;
                    case "ISS":
                        contaIndDRE.indDRE = (int)ContaContabil.indIss;
                        break;
                    case "ICMS":
                        contaIndDRE.indDRE = (int)ContaContabil.indIcms;
                        break;
                    case "ICMS ST":
                        contaIndDRE.indDRE = (int)ContaContabil.indIcmsSt;
                        break;
                    case "IPI":
                        contaIndDRE.indDRE = (int)ContaContabil.indIpi;
                        break;
                    case "ISSQN":
                        contaIndDRE.indDRE = (int)ContaContabil.indIssqn;
                        break;
                    case "COMISSÕES":
                        contaIndDRE.indDRE = (int)ContaContabil.indComissoes;
                        break;
                    case "FRETE SOBRE VENDAS":
                        contaIndDRE.indDRE = (int)ContaContabil.indFreteVendas;
                        break;
                    case "CUSTO MERCADORIA VENDIDA":
                        contaIndDRE.indDRE = (int)ContaContabil.indCustoMercadoriaVendida;
                        break;
                    case "FRETE SOBRE COMPRAS":
                        contaIndDRE.indDRE = (int)ContaContabil.indFreteCompras;
                        break;
                    case "FRETES":
                        contaIndDRE.indDRE = (int)ContaContabil.indFretes;
                        break;
                }
                contaIndDRE.descricao = item.DES_DRE;

                contasIndDRE.contaIndDREs.Add(contaIndDRE);
            }
            contasIndDRE.contaIndDREs.ForEach(x =>
            {
                decimal? vlrConta = 0;
                if (x.indDRE == (int)ContaContabil.indPis)
                {
                    if (filtros.IndRazaoContas)
                    {
                        queryNotasSaida.Where(y => y.VLR_PIS.HasValue && y.VLR_PIS > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                        {
                            var notaTitulo = new NotaTitulo();
                            notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_PIS;
                            notasTitulos.Add(notaTitulo);
                        });
                    }
                    vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_PIS);
                }
                else
                {
                    if (x.indDRE == (int)ContaContabil.indCofins)
                    {
                        if (filtros.IndRazaoContas)
                        {
                            queryNotasSaida.Where(y => y.VLR_COFINS.HasValue && y.VLR_COFINS > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                            {
                                var notaTitulo = new NotaTitulo();
                                notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_COFINS;
                                notasTitulos.Add(notaTitulo);
                            });
                        }
                        vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_COFINS);
                    }
                    else
                    {
                        if (x.indDRE == (int)ContaContabil.indIss)
                        {
                            if (filtros.IndRazaoContas)
                            {
                                queryNotasSaida.Where(y => y.VLR_ISS.HasValue && y.VLR_ISS > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                                {
                                    var notaTitulo = new NotaTitulo();
                                    notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_ISS;
                                    notasTitulos.Add(notaTitulo);
                                });
                            }
                            vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_ISS);
                        }
                        else
                        {
                            if (x.indDRE == (int)ContaContabil.indIcms)
                            {
                                if (filtros.IndRazaoContas)
                                {
                                    queryNotasSaida.Where(y => y.VLR_ICMS.HasValue && y.VLR_ICMS > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                                    {
                                        var notaTitulo = new NotaTitulo();
                                        notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_ICMS;
                                        notasTitulos.Add(notaTitulo);
                                    });
                                }
                                vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_ICMS);
                            }
                            else
                            {

                                if (x.indDRE == (int)ContaContabil.indIcmsSt)
                                {
                                    if (filtros.IndRazaoContas)
                                    {
                                        queryNotasSaida.Where(y => y.VLR_ST.HasValue && y.VLR_ST > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                                        {
                                            var notaTitulo = new NotaTitulo();
                                            notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_ST;
                                            notasTitulos.Add(notaTitulo);
                                        });
                                    }
                                    vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_ST);
                                }
                                else
                                {
                                    if (x.indDRE == (int)ContaContabil.indIpi)
                                    {
                                        if (filtros.IndRazaoContas)
                                        {
                                            queryNotasSaida.Where(y => y.VLR_IPI.HasValue && y.VLR_IPI > 0 && y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).ToList().ForEach(y =>
                                            {
                                                var notaTitulo = new NotaTitulo();
                                                notaTitulo.Descricao = "Nota Saída: " + y.NUM_NOTA + " Valor: " + y.VLR_IPI;
                                                notasTitulos.Add(notaTitulo);
                                            });
                                        }
                                        vlrConta = queryNotasSaida.Where(y => y.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Sum(y => y.VLR_IPI);
                                    }
                                    else
                                    {
                                        if (x.indDRE == (int)ContaContabil.indComissoes)
                                        {
                                            if (filtros.IndComissoes == 1)
                                            {
                                                var queryItensNotaSaidaComissao = queryItensNotaSaida.Where(y => y.COD_OPERACAO_FISCAL != null &&
                                                                                                            y.COD_OPERACAO_FISCALNavigation != null &&
                                                                                                            y.COD_OPERACAO_FISCALNavigation.TIP_CONSIDERAR_COMISSAO.HasValue &&
                                                                                                            y.COD_OPERACAO_FISCALNavigation.TIP_CONSIDERAR_COMISSAO.Value &&
                                                                                                            y.FT_NOTAS_ITENS_COMISSAO.Count > 0).Select(y => y);

                                                if (queryItensNotaSaidaComissao.Count() > 0 && queryItensNotaSaidaComissao.FirstOrDefault().FT_NOTAS_ITENS_COMISSAO.Count() > 0)
                                                {
                                                    if (filtros.IndRazaoContas)
                                                    {
                                                        List<int> notas = new List<int>();
                                                        queryItensNotaSaidaComissao.ToList().ForEach(y =>
                                                        {
                                                            var notaTitulo = new NotaTitulo();
                                                            if (!notas.Where(w => w == y.COD_NOTA).Any())
                                                            {
                                                                var vlrComissao = queryItensNotaSaidaComissao.Sum(y => (y.VLR_TOTAL * y.FT_NOTAS_ITENS_COMISSAO.Where(w => w.COD_ITEM == y.COD_ITEM).FirstOrDefault().PER_COMISSAO ?? 0) / 100);
                                                                notaTitulo.Descricao = "Nota Saída: " + y.COD_NOTANavigation.NUM_NOTA + " Valor: " + vlrComissao;
                                                                notasTitulos.Add(notaTitulo);
                                                            }
                                                            notas.Add(y.COD_NOTA.Value);
                                                        });
                                                    }
                                                    vlrConta = queryItensNotaSaidaComissao.Sum(y => (y.VLR_TOTAL * y.FT_NOTAS_ITENS_COMISSAO.Where(w => w.COD_ITEM == y.COD_ITEM).FirstOrDefault().PER_COMISSAO ?? 0) / 100);
                                                }
                                            }
                                            else
                                            {
                                                //!!!!!!!!Validar com Moa
                                                var queryHistoricoTitulos = queryTitulosReceber.SelectMany(y => y.CR_HISTORICOS);
                                                var queryComissoesTitulosReceber = queryHistoricoTitulos.Where(y => y.DTA_MOVIMENTO.Value.Month == filtros.dtaMesAno.Value.Month
                                                                                                                && y.DTA_MOVIMENTO.Value.Year == filtros.dtaMesAno.Value.Year).SelectMany(y => y.COD_TITULONavigation.CR_TITULOS_COMISSOES);
                                                queryComissoesTitulosReceber.Include(y => y.COD_TITULONavigation)
                                                                             .Include(y => y.COD_TITULONavigation.COD_PESSOANavigation);

                                                vlrConta = queryComissoesTitulosReceber.Sum(y => y.VLR_COMISSAO);
                                                if (queryComissoesTitulosReceber.Count() > 0)
                                                {
                                                    if (filtros.IndRazaoContas)
                                                    {
                                                        List<int> notas = new List<int>();
                                                        queryComissoesTitulosReceber.ToList().ForEach(y =>
                                                        {
                                                            var notaTitulo = new NotaTitulo();
                                                            if (!notas.Where(w => w == y.COD_TITULO).Any())
                                                            {
                                                                var desPessoa = y.COD_TITULONavigation.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? y.COD_TITULONavigation.COD_PESSOANavigation.DES_PESSOA;
                                                                notaTitulo.Descricao = "Título Receber/Parcela - Cliente: " + y.COD_TITULONavigation.NUM_TITULO + "/" + y.COD_TITULONavigation.NUM_PARCELA + " - " + desPessoa + " Valor: " + y.VLR_COMISSAO;
                                                                notasTitulos.Add(notaTitulo);
                                                            }
                                                            notas.Add(y.COD_TITULO);
                                                        });
                                                    }
                                                }
                                                if (vlrConta == 0)
                                                {
                                                    var queryItensNotaSaidaComissao = queryItensNotaSaida.Where(y => y.FT_NOTAS_ITENS_COMISSAO.Count > 0);

                                                    if (queryItensNotaSaidaComissao.Count() > 0)
                                                    {
                                                        if (filtros.IndRazaoContas)
                                                        {
                                                            List<int> notas = new List<int>();
                                                            queryItensNotaSaidaComissao.ToList().ForEach(y =>
                                                            {
                                                                var notaTitulo = new NotaTitulo();
                                                                if (!notas.Where(w => w == y.COD_NOTA).Any())
                                                                {
                                                                    var vlrComissao = y.VLR_TOTAL * (y.FT_NOTAS_ITENS_COMISSAO.Where(w => w.COD_ITEM == y.COD_ITEM).FirstOrDefault().PER_COMISSAO / 100);
                                                                    notaTitulo.Descricao = "Nota Saída: " + y.COD_NOTANavigation.NUM_NOTA + " Valor: " + vlrComissao;
                                                                    notasTitulos.Add(notaTitulo);
                                                                }
                                                                notas.Add(y.COD_NOTA.Value);
                                                            });
                                                        }
                                                        vlrConta = queryItensNotaSaidaComissao.Sum(y => (y.VLR_TOTAL * y.FT_NOTAS_ITENS_COMISSAO.Where(w => w.COD_ITEM == y.COD_ITEM).FirstOrDefault().PER_COMISSAO) / 100);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (x.indDRE == (int)ContaContabil.indFreteVendas)
                                            {
                                                var queryNotasRelacaoSaidas = queryNotasEntrada.Where(x => x.CE_NOTAS_ITENS.Where(y => y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 1353
                                                                                    || y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 5353).Any()
                                                                                    && x.CE_NOTAS_RELACAO_SAIDAS.Count > 0);

                                                if (queryNotasRelacaoSaidas.Count() > 0)
                                                {
                                                    if (filtros.IndRazaoContas)
                                                    {
                                                        queryNotasRelacaoSaidas.Where(y => y.CE_NOTAS_RELACAO_SAIDAS.Where(w => w.COD_NOTA_ENTRADA == y.COD_NOTA &&
                                                                                      w.COD_NOTA_SAIDANavigation.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Any())
                                                        .ToList().ForEach(y =>
                                                        {
                                                            var notaTitulo = new NotaTitulo();
                                                            var desPessoa = y.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? y.COD_PESSOANavigation.DES_PESSOA;
                                                            notaTitulo.Descricao = "Nota Entrada/Fornecedor: " + y.NUM_NOTA + "/" + desPessoa + " Valor: " + y.VLR_TOTAL;
                                                            notasTitulos.Add(notaTitulo);
                                                        });
                                                    }

                                                    vlrConta = queryNotasRelacaoSaidas.Where(x => x.CE_NOTAS_ITENS.Where(y => y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 1353
                                                                                                || y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 5353).Any()
                                                                                                && x.CE_NOTAS_RELACAO_SAIDAS.Where(t => t.COD_NOTA_ENTRADA == x.COD_NOTA
                                                                                                && t.COD_NOTA_SAIDANavigation.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != true).Any()
                                                                                                && x.DTA_ENTRADA.Value.Month == filtros.dtaMesAno.Value.Month
                                                                                                && x.DTA_ENTRADA.Value.Year == filtros.dtaMesAno.Value.Year).Sum(x => x.VLR_TOTAL);
                                                }

                                            }
                                            else
                                            {
                                                if (x.indDRE == (int)ContaContabil.indCustoMercadoriaVendida)
                                                {
                                                    var retorno = RetornarValorContaMercadoriaVendida(filtros);
                                                    vlrConta = retorno.Result.contasDRE.First().valorConta;
                                                    foreach(var titulo in retorno.Result.contasDRE.First().notasTitulos)
                                                    {
                                                        notasTitulos.Add(titulo);
                                                    }
                                                }
                                                else
                                                {
                                                    if (x.indDRE == (int)ContaContabil.indFreteCompras)
                                                    {
                                                        vlrConta = queryNotasEntrada.Where(y => y.CE_NOTAS_ITENS.Where(w => w.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true).FirstOrDefault() != null && y.VLR_FRETE != 0 && y.VLR_FRETE != null).Sum(y => y.VLR_FRETE);
                                                        if (filtros.IndRazaoContas)
                                                        {
                                                            queryNotasEntrada.Where(y => y.CE_NOTAS_ITENS.Where(w => w.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true).FirstOrDefault() != null && y.VLR_FRETE != 0 && y.VLR_FRETE != null)
                                                            .ToList().ForEach(y =>
                                                            {
                                                                var notaTitulo = new NotaTitulo();
                                                                var desPessoa = y.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? y.COD_PESSOANavigation.DES_PESSOA;
                                                                notaTitulo.Descricao = "Nota Entrada/Fornecedor: " + y.NUM_NOTA + "/" + desPessoa + " Valor: " + y.VLR_FRETE;
                                                                notasTitulos.Add(notaTitulo);
                                                            });
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (x.indDRE == (int)ContaContabil.indFretes)
                                                        {
                                                            var notasRelacaoSaida = queryNotasEntrada.SelectMany(y => y.CE_NOTAS_RELACAO_SAIDAS);

                                                            notasRelacaoSaida = notasRelacaoSaida.Include(y => y.COD_NOTA_SAIDANavigation)
                                                                                                    .Include(y => y.COD_NOTA_SAIDANavigation.FT_NOTAS_ITENS);

                                                            vlrConta = queryNotasEntrada.Where(y => (y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 1353
                                                                                                || y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 5353)
                                                                                                && y.CE_NOTAS_RELACAO_SAIDAS != null
                                                                                                && (y.CE_NOTAS_RELACAO_SAIDAS.Where(w => w.COD_NOTA_SAIDANavigation.FT_NOTAS_ITENS != null &&
                                                                                                                                    w.COD_NOTA_SAIDANavigation.FT_NOTAS_ITENS.Where(z => z.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS == true).FirstOrDefault() != null).FirstOrDefault() != null
                                                                                                || y.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADANavigation.Count == 0
                                                                                                || y.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADA_RELACIONADANavigation.Count == 0)).Sum(y => y.VLR_TOTAL);

                                                            if (filtros.IndRazaoContas)
                                                            {
                                                                queryNotasEntrada.Where(y => (y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 1353
                                                                                                || y.COD_OPERACAO_FISCALNavigation.COD_CFOP == 5353)
                                                                                                && y.CE_NOTAS_RELACAO_SAIDAS != null
                                                                                                && (y.CE_NOTAS_RELACAO_SAIDAS.Where(w => w.COD_NOTA_SAIDANavigation.FT_NOTAS_ITENS != null &&
                                                                                                                                    w.COD_NOTA_SAIDANavigation.FT_NOTAS_ITENS.Where(z => z.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS == true).FirstOrDefault() != null).FirstOrDefault() != null
                                                                                                || y.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADANavigation.Count == 0
                                                                                                || y.CE_NOTAS_RELACAO_ENTRADASCOD_NOTA_ENTRADA_RELACIONADANavigation.Count == 0))
                                                                .ToList().ForEach(y =>
                                                                {
                                                                    var notaTitulo = new NotaTitulo();
                                                                    var desPessoa = y.COD_PESSOANavigation.DES_RAZAO_SOCIAL ?? y.COD_PESSOANavigation.DES_PESSOA;
                                                                    notaTitulo.Descricao = "Nota Entrada/Fornecedor: " + y.NUM_NOTA + "/" + desPessoa + " Valor: " + y.VLR_TOTAL;
                                                                    notasTitulos.Add(notaTitulo);
                                                                });
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                if (x.codConta != 0 && vlrConta.HasValue && vlrConta != 0)
                {
                    var conta = new Conta(x.codConta, vlrConta.Value, x.descricao);
                    conta.notaTitulos = new List<NotaTitulo>(notasTitulos);
                    if (Contas.Where(y => y.codConta == conta.codConta).Any())
                        Contas.Where(y => y.codConta == conta.codConta).ToList().ForEach(y => y.valorTotal += conta.valorTotal);
                    else
                        Contas.Add(conta);
                    notasTitulos.Clear();
                    var contaDRE = queryContasDRE.Where(y => y.COD_CONTA_DRE == x.codConta).FirstOrDefault();
                    if (contaDRE.COD_CONTA_DRE != 0 &&
                        contaDRE.COD_DRE_PAI.HasValue)
                    {
                        VerificaPai(queryContasDRE.ToList(), contaDRE.COD_DRE_PAI, vlrConta.Value, ContasPai);
                    }
                }

            });
            var retorno = new RetornoDRE();

            if (filtros.IndConferencia)
            {
                var listaConferencia = new List<Conferencia>();
                queryItensNotaSaida.Where(x => x.COD_CONTA_CONTABIL == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRENavigation == null).ToList()
                .ForEach(x =>
                {
                    bool existeNota = false;
                    if (listaConferencia.Count > 0)
                        existeNota = listaConferencia.Where(y => y.codNota == x.COD_NOTA).Any();

                    var conferencia = new Conferencia();
                    if (!existeNota)
                    {
                        conferencia.codNota = x.COD_NOTA;
                        conferencia.desNota = "Nota de saída: " + x.COD_NOTANavigation.NUM_NOTA;
                        conferencia.valorTotal = x.COD_NOTANavigation.VLR_TOTAL.Value;
                        listaConferencia.Add(conferencia);
                    }

                });
                queryItensNotaEntrada.Where(x => x.COD_CONTA_CONTABIL == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == 0).ToList()
                .ForEach(x =>
                {
                    bool existeNota = false;
                    if (listaConferencia.Count > 0)
                        existeNota = listaConferencia.Where(y => y.codNota == x.COD_NOTA).Any();

                    var conferencia = new Conferencia();
                    if (!existeNota)
                    {
                        conferencia.codNota = x.COD_NOTA;
                        conferencia.desNota = "Nota Entrada/Fornecedor: " + x.COD_NOTANavigation.NUM_NOTA + "/" + x.COD_NOTANavigation.COD_PESSOANavigation?.DES_RAZAO_SOCIAL;
                        conferencia.valorTotal = x.COD_NOTANavigation.VLR_TOTAL.Value;
                        listaConferencia.Add(conferencia);
                    }

                });
                queryTitulosPagar.Where(x => (x.COD_CONTA_CONTABIL == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == 0) &&
                (x.COD_NOTA == null ||
                x.COD_NOTA == 0)).ToList()
                .ForEach(x =>
                {
                    bool existeNota = false;
                    if (listaConferencia.Count > 0)
                        existeNota = listaConferencia.Where(y => y.codNota == x.COD_TITULO).Any();

                    var conferencia = new Conferencia();
                    if (!existeNota)
                    {
                        conferencia.codNota = x.COD_TITULO;
                        conferencia.desNota = "Título Pagar/Fornecedor: " + x.NUM_TITULO + "/" + x.COD_PESSOANavigation?.DES_RAZAO_SOCIAL;
                        conferencia.valorTotal = x.VLR_TITULO.Value;
                        listaConferencia.Add(conferencia);
                    }

                });
                queryTitulosReceber.Where(x => (x.COD_CONTA_CONTABIL == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == null ||
                x.COD_CONTA_CONTABILNavigation.COD_DRE == 0) &&
                (x.COD_NOTA == null ||
                x.COD_NOTA == 0)).ToList()
                .ForEach(x =>
                {
                    bool existeNota = false;
                    if (listaConferencia.Count > 0)
                        existeNota = listaConferencia.Where(y => y.codNota == x.COD_TITULO).Any();

                    var conferencia = new Conferencia();
                    if (!existeNota)
                    {
                        conferencia.codNota = x.COD_TITULO;
                        conferencia.desNota = "Título Receber/Parcela - Cliente: " + x.NUM_TITULO + "/" + x.COD_PESSOANavigation?.DES_RAZAO_SOCIAL;
                        conferencia.valorTotal = x.VLR_TITULO.Value;
                        listaConferencia.Add(conferencia);
                    }

                });
                retorno.conferenciasDRE = listaConferencia;
            }
            var contasDRE = new Contas();
            contasDRE.contas = Contas;
            contasDRE.contaPais = ContasPai;

            var ListContasDRE = queryContasDRE.ToList();

            var arvore = ConstruirArvore(ListContasDRE, contasDRE);
            retorno.contasDRE = arvore;
            return retorno;
        }


        public List<ContaDRE> ConstruirArvore(List<GE_DRE> sW_CONTAS_DREs, Contas contas)
        {
            var contasDRE = new List<ContaDRE>();
            int nivel = 0;
            int codContaPai = 0;
            foreach (var linha in sW_CONTAS_DREs)
            {
                var listaTitulosNotas = new List<NotaTitulo>();
                int codigo = linha.COD_CONTA_DRE.Value;
                string nome = linha.DES_DRE;
                int codigoPai = linha.COD_DRE_PAI ?? 0;
                decimal vlrConta = 0;
                decimal valor = 0;
                vlrConta = contas.contaPais.Where(x => x.codConta == linha.COD_CONTA_DRE.Value).Sum(x => x.valorTotal);
                if (vlrConta != 0)
                    valor = vlrConta + contas.contas.Where(x => x.codConta == linha.COD_CONTA_DRE.Value).Sum(x => x.valorTotal);
                else
                    valor = contas.contas.Where(x => x.codConta == linha.COD_CONTA_DRE.Value).Sum(x => x.valorTotal);
                if (contas.contas.Where(x => x.codConta == linha.COD_CONTA_DRE.Value && x.notaTitulos.Count > 0).Any())
                {
                    listaTitulosNotas = contas.contas.Where(x => x.codConta == linha.COD_CONTA_DRE.Value).FirstOrDefault().notaTitulos;
                }
                var conta = new ContaDRE(codigo, nome, valor);

                if (codigoPai == 0)
                {
                    conta.nivelConta = 0;
                    conta.notasTitulos = listaTitulosNotas;
                    contasDRE.Add(conta);
                }
                else
                {
                    // Encontrar a conta pai
                    var contaPai = EncontrarContaPai(contasDRE, codigoPai);
                    if (contaPai != null)
                    {
                        conta.nivelConta = contaPai.nivelConta + 1; // Incrementar o nível baseado no nível do pai
                        conta.notasTitulos = listaTitulosNotas;
                        contaPai.Subcontas.Add(conta);
                    }
                    else
                    {
                        // Caso a conta pai não seja encontrada, adiciona no nível 0
                        conta.nivelConta = 0;
                        conta.notasTitulos = listaTitulosNotas;
                        contasDRE.Add(conta);
                    }
                }
            }
            return contasDRE;
        }

        private ContaDRE EncontrarContaPai(List<ContaDRE> contas, int codigoPai)
        {
            foreach (var c in contas)
            {
                if (c.Codigo == codigoPai)
                {
                    return c;
                }
                var subContaPai = EncontrarContaPai(c.Subcontas, codigoPai);
                if (subContaPai != null)
                {
                    return subContaPai;
                }
            }
            return null;
        }
        private void VerificaPai(List<GE_DRE> gE_DREs, int? codContaPai, decimal vlrConta, List<ContaPai> ContasPai)
        {
            var desConta = gE_DREs.Where(x => x.COD_CONTA_DRE == codContaPai).FirstOrDefault()?.DES_DRE;
            var contaPai = new ContaPai(codContaPai, vlrConta, desConta);
            if (ContasPai.Where(y => y.codConta == codContaPai).Any())
                ContasPai.Where(y => y.codConta == codContaPai).ToList().ForEach(y => y.valorTotal += vlrConta);
            else
                ContasPai.Add(contaPai);

            if (gE_DREs.Where(x => x.COD_CONTA_DRE == codContaPai).FirstOrDefault()?.COD_DRE_PAI != null &&
                gE_DREs.Where(x => x.COD_CONTA_DRE == codContaPai).FirstOrDefault()?.COD_DRE_PAI != 0)
            {
                VerificaPai(gE_DREs, gE_DREs.Where(x => x.COD_CONTA_DRE == codContaPai).FirstOrDefault().COD_DRE_PAI, vlrConta, ContasPai);
            }
        }

        public async Task<RetornoDRE> RetornarValorContaMercadoriaVendida(ConfiguradorRelatorioDREDto filtros)
        {
            var data = new DateTime(filtros.dtaMesAno.Value.Year, filtros.dtaMesAno.Value.Month, 1);

            var empresasPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(filtros.dadosAcessoModelDRE.CodigoEmpresa);
            var empresaPadraoContaDRE = empresasPadrao[EmpresaPadrao.ContaDRE].CodEmpresaPadrao;


            var queryNotasItens = _repositorioErp.Query<CE_NOTAS_ITENS>().Where(x => x.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true &&
                                                                                x.COD_NOTANavigation.DTA_ENTRADA.Value >= data &&
                                                                                x.COD_NOTANavigation.DTA_ENTRADA.Value <= filtros.dtaMesAno.Value && 
                                                                                x.COD_NOTANavigation.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa &&
                                                                                (x.QTD_CONVERTIDA == null || x.QTD_CONVERTIDA == 0));

            var queryNotasItensConvertida = _repositorioErp.Query<CE_NOTAS_ITENS>().Where(x => x.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true &&
                                                                    x.COD_NOTANavigation.DTA_ENTRADA.Value >= data &&
                                                                    x.COD_NOTANavigation.DTA_ENTRADA.Value <= filtros.dtaMesAno.Value &&
                                                                    x.COD_NOTANavigation.COD_EMPRESA == filtros.dadosAcessoModelDRE.CodigoEmpresa &&
                                                                    x.QTD_CONVERTIDA > 0);

            var queryContaDRE = _repositorioErp.Query<GE_DRE>().Where(x => x.COD_EMPRESA == empresaPadraoContaDRE &&
                                                                      x.DES_DRE.ToUpper().Equals("CUSTO MERCADORIA VENDIDA"));

            var notasTitulos = new List<NotaTitulo>();

            var listaProdutoCusto = queryNotasItens
            .Where(x => (x.QTD_CONVERTIDA == 0 || x.QTD_CONVERTIDA == null) && x.QTD_PRODUTO > 0 && x.COD_PRODUTO != null)
            .Select(x => new {
                codProduto = x.COD_PRODUTO,
                codAlmoxarifado = x.COD_ALMOXARIFADO,
                desAlmox = x.COD_ALMOXARIFADONavigation.DES_ALMOXARIFADO,
                codSKU = x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA ?? "", // Usando operador nulo condicional e coalescência nula

                qtdMovimentoEntrada = x.QTD_PRODUTO * x.COD_MOVIMENTO_ESTOQUENavigation.VLR_CUSTO_MEDIO ?? 0
            // Conversão para nullable e coalescência nula
            }).ToList();

            var listaProdutoCustoConvertida = queryNotasItensConvertida
            .Where(x => x.QTD_CONVERTIDA > 0)
            .Select(x => new
            {
                codProduto = x.COD_PRODUTO,
                codAlmoxarifado = x.COD_ALMOXARIFADO,
                desAlmox = x.COD_ALMOXARIFADONavigation.DES_ALMOXARIFADO,
                codSKU = x.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA ?? "", // Usando operador nulo condicional e coalescência nula

                qtdMovimentoEntrada = x.QTD_CONVERTIDA * x.COD_MOVIMENTO_ESTOQUENavigation.VLR_CUSTO_MEDIO ?? 0
                // Conversão para nullable e coalescência nula
            }).ToList();


            var dadosAcesso = new DadosAcessoModel();
            dadosAcesso.CodigoOrganizacao = filtros.dadosAcessoModelDRE.CodigoOrganizacao;
            dadosAcesso.CodigoEmpresa = filtros.dadosAcessoModelDRE.CodigoEmpresa;
            dadosAcesso.CodigoUsuario = filtros.dadosAcessoModelDRE.CodigoUsuario;

            var dto = new ConfiguradorRelatorioInventarioDto();
            dto.DtaReferencia = data.AddSeconds(-1);
            dto.MesAnoReferencia = new DateTime(dto.DtaReferencia.Value.Year, dto.DtaReferencia.Value.Month, 1);
            dto.TipProdutosDesativados = false;
            dto.TipListarComEstoqueNegativo = false;
            dto.IndCampoValor = CampoValor.CustoMedio;
            dto.DadosAcesso = dadosAcesso;
            dto.IndOrdem = 0;
            dto.TipListarApenasComQtdeEstoque = false;
            var DtoProdutosMesAnterior = _servicoRelatorioInventario.RetornarRelatorioInventario(dto);

            var dtoInventario = new ConfiguradorRelatorioInventarioDto();
            dtoInventario.DtaReferencia = filtros.dtaMesAno;
            dtoInventario.MesAnoReferencia = new DateTime(filtros.dtaMesAno.Value.Year, filtros.dtaMesAno.Value.Month, 1);
            dtoInventario.TipProdutosDesativados = false;
            dtoInventario.TipListarComEstoqueNegativo = false;
            dtoInventario.IndCampoValor = CampoValor.CustoMedio;
            dtoInventario.DadosAcesso = dadosAcesso;
            dtoInventario.IndOrdem = 0;
            dtoInventario.TipListarApenasComQtdeEstoque = false;
            var DtoProdutosMesAtual = _servicoRelatorioInventario.RetornarRelatorioInventario(dtoInventario);


            decimal vlrConta = 0;
            decimal CustoFinalTotal = 0;
            decimal estoqueIniTotal = DtoProdutosMesAnterior.Result.vlrTotal;
            decimal estoqueFinalTotal = DtoProdutosMesAtual.Result.vlrTotal;

            listaProdutoCusto.ForEach(x =>
            {
                CustoFinalTotal += x.qtdMovimentoEntrada;
            });

            listaProdutoCustoConvertida.ForEach(x =>
            {
                CustoFinalTotal += x.qtdMovimentoEntrada;
            });

            vlrConta = (estoqueIniTotal + CustoFinalTotal) - estoqueFinalTotal;

            decimal estoqueIni = 0;
            decimal estoquefinal = 0;
            decimal custof = 0;
            DtoProdutosMesAtual.Result.produtos.ToList().ForEach(x =>
            {
                if(DtoProdutosMesAnterior.Result.produtos.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault() == null)
                {
                    estoqueIni = DtoProdutosMesAnterior.Result.produtos.Where(y => y.codProduto == x.codProduto).FirstOrDefault()?.vlrTotal ?? 0;
                    estoquefinal = 0;
                    custof = listaProdutoCusto.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault()?.qtdMovimentoEntrada ?? 0;
                    custof += listaProdutoCustoConvertida.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault()?.qtdMovimentoEntrada ?? 0;

                }
                else
                {
                    estoqueIni = DtoProdutosMesAnterior.Result.produtos.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault()?.vlrTotal ?? 0;
                    estoquefinal = x.vlrTotal;
                    custof = listaProdutoCusto.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault()?.qtdMovimentoEntrada ?? 0;
                    custof += listaProdutoCustoConvertida.Where(y => y.codProduto == x.codProduto && y.desAlmox.Equals(x.desAlmox)).FirstOrDefault()?.qtdMovimentoEntrada ?? 0;

                }
                if (filtros.IndRazaoContas)
                {
                    var notaTitulo = new NotaTitulo();
                    notaTitulo.Descricao = "Produto: " + x.codSku + " EI = " + estoqueIni.ToString("F") + " Custo = " + custof.ToString("F") + " EF = " + estoquefinal.ToString("F");
                    notasTitulos.Add(notaTitulo);
                }

            });

            var desConta = "";
            var codConta = 0;
            if(queryContaDRE != null && queryContaDRE.Count() > 0)
            {
                desConta = queryContaDRE.FirstOrDefault().DES_DRE;
                codConta = queryContaDRE.FirstOrDefault().COD_CONTA_DRE.Value;
            }

            var conta = new ContaDRE(codConta, desConta, vlrConta);
            conta.notasTitulos = notasTitulos;

            var retorno = new RetornoDRE();
            retorno.contasDRE.Add(conta);
   
            return retorno;
        }
    }
}

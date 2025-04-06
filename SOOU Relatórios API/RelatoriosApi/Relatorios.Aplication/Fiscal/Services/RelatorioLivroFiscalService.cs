using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.Fiscal.Models;
using Relatorios.Aplication.Fiscal.Models.ApuracaoIcms;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Relatorios.Aplication.Fiscal.Models.ItemLivroEntradaResult;

namespace Relatorios.Aplication.Fiscal.Services
{
    public interface IRelatorioLivroFiscalService
    {
        Task<Result<RelatorioLivroEntradaResult, Error>> RelatorioLivroEntrada(RelatorioLivroEntradaRequest request);
        Task<Result<RelatorioLivroSaidaResult, Error>> RelatorioLivroSaida(RelatorioLivroSaidaRequest request);
        Task<Result<RelatorioApuracaoIcmsEntradasSaidasResult, Error>> RelatorioApuracaoIcms(RelatorioApuracaoIcmsRequest request);
    }

    public class RelatorioLivroFiscalService : IRelatorioLivroFiscalService
    {


        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;
        private readonly IErpRepositorioGenerico _erpRepositorioGenerico;

        private readonly RelatorioLivroSaidasService _relatorioLivroSaidasService;
        private readonly RelatorioApuracaoIcmsService _relatorioApuracaoIcmsService;

        public RelatorioLivroFiscalService(
            IErpRepositorioGenerico erpRepositorioGenerico,
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao,
            RelatorioLivroSaidasService relatorioLivroSaidasService,
            RelatorioApuracaoIcmsService relatorioApuracaoIcmsService)
        {
            _erpRepositorioGenerico = erpRepositorioGenerico;
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
            _relatorioLivroSaidasService = relatorioLivroSaidasService;
            _relatorioApuracaoIcmsService = relatorioApuracaoIcmsService;
        }


        public async Task<Result<RelatorioLivroEntradaResult, Error>> RelatorioLivroEntrada(RelatorioLivroEntradaRequest request)
        {
            var empresaPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(request.CodEmpresa);

            var queryEntrada = _erpRepositorioGenerico.Query<CE_NOTAS_ITENS>();
            queryEntrada = filtrarQueryLivroEntrada(queryEntrada, request);

            var queryDevolucoes = _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            queryDevolucoes = filtrarQueryLivroEntradaDevolucoes(queryDevolucoes, request);

            var resultadoEntradas = await MapToItemLivroEntrada(queryEntrada).ToListAsync();
            var resultadoDevolucao = await MapToItemLivroEntradaDevolucao(queryDevolucoes).ToListAsync();

            var itens = resultadoEntradas.Concat(resultadoDevolucao).OrderBy(n => n.DtaEmissao).ToList();

            return new RelatorioLivroEntradaResult()
            {
                Itens = itens
            };
        }

        private static IQueryable<ItemLivroEntradaResult> MapToItemLivroEntrada(IQueryable<CE_NOTAS_ITENS> queryEntrada)
        {
            return queryEntrada
                .GroupBy(i => i.COD_NOTA)
                .Select(g => new ItemLivroEntradaResult()
                {
                    CodNota = g.Key,
                    Numero = g.First().COD_NOTANavigation.NUM_NOTA ?? 0,
                    Serie = g.First().COD_NOTANavigation.DES_SERIE,
                    DtaEmissao = g.First().COD_NOTANavigation.DTA_EMISSAO,
                    DtaEntrada = g.First().COD_NOTANavigation.DTA_ENTRADA,
                    CodOperacaoFiscalCabecalho = g.First().COD_NOTANavigation.COD_OPERACAO_FISCAL,
                    CfopCabecalho = g.First().COD_NOTANavigation!.COD_OPERACAO_FISCALNavigation!.COD_CFOP,
                    CodEmpresa = g.First().COD_NOTANavigation.COD_EMPRESA,
                    Emitente = new EmitenteModel()
                    {
                        Codigo = g.First().COD_NOTANavigation.COD_PESSOA ?? 0,
                        DesEmitente = g.First().COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA,
                        SiglaUF = g.First().COD_NOTANavigation.COD_PESSOANavigation.PS_ENDERECOS.FirstOrDefault().COD_CIDADENavigation.COD_IBGE_UFNavigation.DES_ABREVIATURA
                    },
                    VlrTotal = g.Sum(i => i.VLR_MERCADORIA + i.VLR_FCP_ST - i.VLR_DESCONTO + i.VLR_FRETE + i.VLR_SEGURO + i.VLR_DESPESAS) ?? 0,
                    IsDevolucao = false,
                    VlrBaseIcms = g.Sum(i => i.VLR_BASE_ICMS ?? 0),
                    VlrIcms = g.Sum(i => i.VLR_ICMS ?? 0),
                    PerIcms = g.Sum(i => i.PER_ICMS ?? 0),
                    VlrIpi = g.Sum(i => i.VLR_IPI ?? 0),
                    VlrBaseIpi = g.Sum(i => i.VLR_BASE_IPI ?? 0),
                    VlrST = g.Sum(i => i.VLR_ICMS_SUBSTITUTO ?? 0),
                    VlrBaseST = g.Sum(i => i.VLR_BASE_ST ?? 0),
                    VlrDesconto = g.Sum(i => i.VLR_DESCONTO ?? 0),
                    VlrOutras = g.Sum(i => (i.VLR_MERCADORIA + i.VLR_DESPESAS) - (i.VLR_BASE_ICMS + i.VLR_DESCONTO + i.VLR_ICMS +
                         (i.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? i.VLR_PIS : 0)
                    )),
                    DesObservacao = "",
                });
        }

        private static IQueryable<ItemLivroEntradaResult> MapToItemLivroEntradaDevolucao(IQueryable<FT_NOTAS_ITENS> queryEntrada)
        {
            return queryEntrada
                .GroupBy(i => i.COD_NOTA)
                .Select(g => new ItemLivroEntradaResult()
                {
                    CodNota = g.Key ?? 0,
                    Numero = g.First().COD_NOTANavigation.NUM_NOTA,
                    Serie = g.First().COD_NOTANavigation.DES_SERIE,
                    DtaEmissao = g.First().COD_NOTANavigation.DTA_EMISSAO,
                    CodOperacaoFiscalCabecalho = g.First().COD_NOTANavigation.COD_OPERACAO_FISCAL,
                    CfopCabecalho = g.First().COD_NOTANavigation!.COD_OPERACAO_FISCALNavigation!.COD_CFOP,
                    CodEmpresa = g.First().COD_NOTANavigation.COD_EMPRESA,
                    Emitente = new EmitenteModel()
                    {
                        Codigo = g.First().COD_NOTANavigation.COD_PESSOA ?? 0,
                        DesEmitente = g.First().COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA,
                        SiglaUF = g.First().COD_NOTANavigation.COD_PESSOANavigation.PS_ENDERECOS.FirstOrDefault().COD_CIDADENavigation.COD_IBGE_UFNavigation.DES_ABREVIATURA
                    },
                    VlrTotal = g.Sum(i => i.VLR_MERCADORIA + i.VLR_BASE_FUNDO_COMBATE_POBREZA_ST - i.VLR_DESCONTO + i.VLR_FRETE + i.VLR_SEGURO + i.VLR_DESPESAS) ?? 0,
                    IsDevolucao = true,
                    VlrBaseIcms = g.Sum(i => i.VLR_BASE_ICMS ?? 0),
                    VlrIcms = g.Sum(i => i.VLR_ICMS ?? 0),
                    PerIcms = g.Sum(i => i.PER_ICMS ?? 0),
                    VlrIpi = g.Sum(i => i.VLR_IPI ?? 0),
                    VlrBaseIpi = g.Sum(i => i.VLR_BASE_IPI ?? 0),
                    VlrST = g.Sum(i => i.VLR_ICMS_SUBSTITUTO ?? 0),
                    VlrBaseST = g.Sum(i => i.VLR_BASE_ST ?? 0),
                    VlrDesconto = g.Sum(i => i.VLR_DESCONTO ?? 0),
                    VlrOutras = g.Sum(i => (i.VLR_MERCADORIA + i.VLR_DESPESAS) - (i.VLR_BASE_ICMS + i.VLR_DESCONTO + i.VLR_ICMS +
                        (i.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? i.VLR_PIS : 0)
                    )),
                    DesObservacao = "Devolução",
                });
        }



        private IQueryable<CE_NOTAS_ITENS> filtrarQueryLivroEntrada(IQueryable<CE_NOTAS_ITENS> query, RelatorioLivroEntradaRequest filtro)
        {

            query = query.Where(item => item.COD_NOTANavigation.COD_EMPRESA == filtro.CodEmpresa);
            query = query.Where(nota => nota.COD_NOTANavigation.DTA_EMISSAO >= filtro.DtaInicial.Date);
            query = query.Where(item => item.COD_NOTANavigation.IND_SITUACAO_NOTA == (int)TipoSituacaoNotaEntrada.Confirmada);


            var dtaFinalNormalizada = filtro.DtaFinal.AddDays(1).Date;
            query = query.Where(nota => nota.COD_NOTANavigation.DTA_EMISSAO < dtaFinalNormalizada);

            if (filtro.Cfops.Any())
                query = query.Where(nota => filtro.Cfops.Contains(nota.COD_OPERACAO_FISCALNavigation!.COD_CFOP ?? 0));

            query = query.Where(i => i.COD_OPERACAO_FISCALNavigation!.TIP_NAO_LISTAR_LIVROS != true);

            return query;
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryLivroEntradaDevolucoes(IQueryable<FT_NOTAS_ITENS> query, RelatorioLivroEntradaRequest filtro)
        {
            query = query.Where(item => item.COD_NOTANavigation.COD_EMPRESA == filtro.CodEmpresa);
            query = query.Where(nota => nota.COD_NOTANavigation.DTA_EMISSAO >= filtro.DtaInicial.Date);
            query = query.Where(nota => nota.COD_NOTANavigation.IND_SITUACAO == (int)TipoSituacaoNota.Emitida);

            var dtaFinalNormalizada = filtro.DtaFinal.AddDays(1).Date;
            query = query.Where(nota => nota.COD_NOTANavigation.DTA_EMISSAO < dtaFinalNormalizada);

            if (filtro.Cfops.Any())
                query = query.Where(nota => filtro.Cfops.Contains(nota.COD_OPERACAO_FISCALNavigation!.COD_CFOP ?? 0));

            query = query.Where(i => i.COD_OPERACAO_FISCALNavigation!.TIP_NAO_LISTAR_LIVROS != true)
                .Where(n => n.FT_DEVOLUCOES.Any(d => d.COD_NOTA_SAIDANavigation.DTA_CANCELAMENTO == null));

            return query;
        }

        public Task<Result<RelatorioLivroSaidaResult, Error>> RelatorioLivroSaida(RelatorioLivroSaidaRequest request) => 
            _relatorioLivroSaidasService.RelatorioLivroSaida(request);

        public Task<Result<RelatorioApuracaoIcmsEntradasSaidasResult, Error>> RelatorioApuracaoIcms(RelatorioApuracaoIcmsRequest request) => 
            _relatorioApuracaoIcmsService.RelatorioApuracaoIcmsEntradasSaidas(request);
    }
}

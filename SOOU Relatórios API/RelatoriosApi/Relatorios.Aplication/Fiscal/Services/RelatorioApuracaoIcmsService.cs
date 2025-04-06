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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Fiscal.Services
{
    public class RelatorioApuracaoIcmsService
    {

        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;
        private readonly IErpRepositorioGenerico _erpRepositorioGenerico;

        public RelatorioApuracaoIcmsService(
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao,
            IErpRepositorioGenerico erpRepositorioGenerico)
        {
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
            _erpRepositorioGenerico = erpRepositorioGenerico;
        }

        internal async Task<Result<RelatorioApuracaoIcmsEntradasSaidasResult, Error>> RelatorioApuracaoIcmsEntradasSaidas(RelatorioApuracaoIcmsRequest request)
        {
            var entradas = await RelatorioApuracaoIcmsEntradas(request);

            if (entradas.IsFailure)
                return entradas.Error!;

            var saidas = await RelatorioApuracaoIcmsSaidas(request);

            if (saidas.IsFailure)
                return saidas.Error!;

            return new RelatorioApuracaoIcmsEntradasSaidasResult(entradas.Value!, saidas.Value!);
        }

        internal async Task<Result<RelatorioApuracaoIcmsResult, Error>> RelatorioApuracaoIcmsEntradas(RelatorioApuracaoIcmsRequest request)
        {
            if (request.DtaInicial == null)
                return ErroApuracaoIcms.DataInicialObrigatorio;

            if (request.DtaFinal == null)
                return ErroApuracaoIcms.DataFinalObrigatorio;

            var queryEntradas = _erpRepositorioGenerico.Query<CE_NOTAS_ITENS>();
            queryEntradas = filtrarQueryApuracaoIcmsEntradas(queryEntradas, request);

            var queryDevolucoes= _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            queryDevolucoes = filtrarQueryApuracaoIcmsSaidas(queryDevolucoes, request);
            queryDevolucoes = filtrarQueryApuracaoIcmsSaidasDevolucoes(queryDevolucoes);

            var queryCfops = _erpRepositorioGenerico.Query<SW_CFOP>();

            var resultadoEntradas = await MapToItemApuracaoIcmsEntradas(queryEntradas, queryCfops, request.TipDescricaoCfop).ToListAsync();
            var resultadoDevolucoesEntradas = await MapToItemApuracaoIcmsDevolucoesEntrada(queryDevolucoes, queryCfops, request.TipDescricaoCfop).ToListAsync();

            var itens = resultadoEntradas.Concat(resultadoDevolucoesEntradas).GroupBy(x => x.CodCfop).ToList();

            return new RelatorioApuracaoIcmsBuilder(itens).CriarRelatorioEntradas();
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryApuracaoIcmsSaidasDevolucoes(IQueryable<FT_NOTAS_ITENS> queryDevolucoes)
        {
            return queryDevolucoes
                .Where(i => i.FT_DEVOLUCOES.Any(d => d.COD_NOTA_SAIDANavigation.DTA_CANCELAMENTO == null)
                    && i.COD_CFOP < 5000);
        }

        internal async Task<Result<RelatorioApuracaoIcmsResult, Error>> RelatorioApuracaoIcmsSaidas(RelatorioApuracaoIcmsRequest request)
        {
            if (request.DtaInicial == null)
                return ErroApuracaoIcms.DataInicialObrigatorio;

            if (request.DtaFinal == null)
                return ErroApuracaoIcms.DataFinalObrigatorio;

            var querySaidas = _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            querySaidas = filtrarQueryApuracaoIcmsSaidas(querySaidas, request);

            querySaidas = querySaidas.Where(i => i.COD_CFOP > 5000);

            var queryCfops = _erpRepositorioGenerico.Query<SW_CFOP>();

            var resultadoSaidas = await MapToItemApuracaoIcmsDevolucoesEntrada(querySaidas, queryCfops, request.TipDescricaoCfop).ToListAsync();

            var itens = resultadoSaidas.GroupBy(x => x.CodCfop).ToList();

            return new RelatorioApuracaoIcmsBuilder(itens).CriarRelatorioSaidas();
        }


        private IQueryable<CE_NOTAS_ITENS> filtrarQueryApuracaoIcmsEntradas(IQueryable<CE_NOTAS_ITENS> query, RelatorioApuracaoIcmsRequest filtro)
        {
            query = query.Where(item => item.COD_NOTANavigation.COD_EMPRESA == filtro.CodEmpresa);

            query = query.Where(item => item.COD_NOTANavigation.DTA_EMISSAO >= filtro.DtaInicial!.Value.Date);

            var dtaFinalNormalizada = filtro.DtaFinal.Value.AddDays(1).Date;
            query = query.Where(item => item.COD_NOTANavigation.DTA_EMISSAO < dtaFinalNormalizada);

            return query;
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryApuracaoIcmsSaidas(IQueryable<FT_NOTAS_ITENS> query, RelatorioApuracaoIcmsRequest filtro)
        {
            query = query.Where(item => item.COD_NOTANavigation!.COD_EMPRESA == filtro.CodEmpresa)
                .Where(item => item.COD_NOTANavigation!.DTA_EMISSAO >= filtro.DtaInicial!.Value.Date)
                .Where(item => item.COD_NOTANavigation!.IND_SITUACAO == (int)TipoSituacaoNota.Emitida);

            var dtaFinalNormalizada = filtro.DtaFinal.Value.AddDays(1).Date;
            query = query.Where(item => item.COD_NOTANavigation!.DTA_EMISSAO < dtaFinalNormalizada);

            return query;
        }


        private static IQueryable<ItemApuracaoIcmsResult> MapToItemApuracaoIcmsEntradas(IQueryable<CE_NOTAS_ITENS> queryEntrada, IQueryable<SW_CFOP> queryCfops, bool tipDescricaoCfop)
        {

            return queryEntrada
                .Select(g => new ItemApuracaoIcmsResult()
                {
                    CodCfop = g.COD_CFOP ?? 0,
                    DesCfop = tipDescricaoCfop 
                        ? queryCfops.FirstOrDefault(c => c.COD_CFOP == g.COD_CFOP).DES_CFOP 
                        : "",
                    Valor = g.VLR_MERCADORIA + g.VLR_FCP_ST - g.VLR_DESCONTO + g.VLR_FRETE + g.VLR_SEGURO + g.VLR_DESPESAS ?? 0,
                    VlrBaseCalculo = g.VLR_BASE_ICMS ?? 0,
                    VlrImposto = g.VLR_ICMS ?? 0,
                    VlrIsentaNaoTrib = g.VLR_MERCADORIA + g.VLR_DESPESAS - g.VLR_BASE_ICMS - g.VLR_DESCONTO - g.VLR_ICMS - g.VLR_PIS
                        - (g.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? g.VLR_PIS : 0) ?? 0,
                    VlrOutras = g.VLR_MERCADORIA + g.VLR_DESPESAS - g.VLR_BASE_ICMS - g.VLR_DESCONTO - g.VLR_ICMS
                        - (g.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? g.VLR_PIS : 0) ?? 0,
                }) ;
        }

        private static IQueryable<ItemApuracaoIcmsResult> MapToItemApuracaoIcmsDevolucoesEntrada(IQueryable<FT_NOTAS_ITENS> query, IQueryable<SW_CFOP> queryCfops, bool tipDescricaoCfop)
        {

            return query
                .Select(g => new ItemApuracaoIcmsResult()
                {
                    CodCfop = g.COD_CFOP ?? 0,
                    DesCfop = tipDescricaoCfop 
                        ? queryCfops.FirstOrDefault(c => c.COD_CFOP == g.COD_CFOP).DES_CFOP 
                        : "",
                    Valor = g.VLR_MERCADORIA + g.VLR_FUNDO_COMBATE_POBREZA_ST - g.VLR_DESCONTO + g.VLR_FRETE + g.VLR_SEGURO + g.VLR_DESPESAS ?? 0,
                    VlrBaseCalculo = g.VLR_BASE_ICMS ?? 0,
                    VlrImposto = g.VLR_ICMS ?? 0,
                    VlrIsentaNaoTrib = g.VLR_MERCADORIA + g.VLR_DESPESAS - g.VLR_BASE_ICMS - g.VLR_DESCONTO - g.VLR_ICMS - g.VLR_PIS
                        - (g.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? g.VLR_PIS : 0) ?? 0,
                    VlrOutras = g.VLR_MERCADORIA + g.VLR_DESPESAS - g.VLR_BASE_ICMS - g.VLR_DESCONTO - g.VLR_ICMS
                        - (g.COD_OPERACAO_FISCALNavigation.TIP_NAO_GERAR_PIS == true ? g.VLR_PIS : 0) ?? 0,
                });
        }

    }

    internal static class ErroApuracaoIcms
    {
        private static string DescricaoClasse = "ApuracaoIcms";
        public static Error DataInicialObrigatorio => new Error($"{DescricaoClasse}.DataInicialObrigatorio", "Data inicial é campo obrigatório");
        public static Error DataFinalObrigatorio => new Error($"{DescricaoClasse}.DataFinalObrigatorio", "Data final é campo obrigatório");
    }

}

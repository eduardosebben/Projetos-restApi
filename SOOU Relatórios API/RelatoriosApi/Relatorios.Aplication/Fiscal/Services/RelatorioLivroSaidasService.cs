using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.Fiscal.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.Fiscal.Services
{
    public class RelatorioLivroSaidasService
    {
        
        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;
        private readonly IErpRepositorioGenerico _erpRepositorioGenerico;

        public RelatorioLivroSaidasService(
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao,
            IErpRepositorioGenerico erpRepositorioGenerico)
        {
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
            _erpRepositorioGenerico = erpRepositorioGenerico;
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryLivroSaida(IQueryable<FT_NOTAS_ITENS> query, RelatorioLivroSaidaRequest filtro)
        {
            query = query.Where(item => item.COD_NOTANavigation.COD_EMPRESA == filtro.CodEmpresa);

            query = query.Where(item => item.COD_NOTANavigation.DTA_EMISSAO >= filtro.DtaInicial!.Value.Date);

            var dtaFinalNormalizada = filtro.DtaFinal.Value.AddDays(1).Date;
            query = query.Where(item => item.COD_NOTANavigation.DTA_EMISSAO < dtaFinalNormalizada);

            if (filtro.Cfops.Any())
                query = query.Where(item => filtro.Cfops.Contains(item.COD_OPERACAO_FISCALNavigation!.COD_CFOP ?? 0));

            if (filtro.Clientes.Any())
                query = query.Where(item => filtro.Clientes.Contains(item.COD_NOTANavigation.COD_PESSOA ?? 0));

            query = query.Where(i => i.COD_OPERACAO_FISCALNavigation!.TIP_NAO_LISTAR_LIVROS != true);

            query = query.Where(i => i.COD_CFOP > 5000);

            return query;
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryLivroSaidaCanceladas(IQueryable<FT_NOTAS_ITENS> query)
        {
            return query.Where(item => item.COD_NOTANavigation.IND_SITUACAO == (int)TipoSituacaoNota.Cancelada);
        }

        private IQueryable<FT_NOTAS_ITENS> filtrarQueryLivroSaidaNotasEmitidas(IQueryable<FT_NOTAS_ITENS> query)
        {
            return query.Where(item => item.COD_NOTANavigation.IND_SITUACAO == (int)TipoSituacaoNota.Emitida);
        }

        public async Task<Result<RelatorioLivroSaidaResult, Error>> RelatorioLivroSaida(RelatorioLivroSaidaRequest request)
        {
            if (request.DtaInicial == null)
                return ErroLivroSaidas.DataInicialObrigatorio;

            if (request.DtaFinal == null)
                return ErroLivroSaidas.DataFinalObrigatorio;

            var empresaPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(request.CodEmpresa);

            var queryValidas = _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            queryValidas = filtrarQueryLivroSaida(queryValidas, request);
            queryValidas = filtrarQueryLivroSaidaNotasEmitidas(queryValidas);

            var queryCanceladas = _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            queryCanceladas = filtrarQueryLivroSaida(queryCanceladas, request);
            queryCanceladas = filtrarQueryLivroSaidaCanceladas(queryCanceladas);

            var resultadoSaidas = await MapToItemLivroSaida(queryValidas).ToListAsync();
            var resultadoCanceladas = await MapToItemLivroSaidaCanceladas(queryCanceladas).ToListAsync();

            var itens = resultadoSaidas.Concat(resultadoCanceladas).OrderBy(n => n.DtaEmissao).ToList();

            return new RelatorioLivroSaidaResult()
            {
                Itens = itens
            };
        }

        private static IQueryable<ItemLivroSaidaResult> MapToItemLivroSaida(IQueryable<FT_NOTAS_ITENS> querySaidas)
        {
            return querySaidas
                .GroupBy(i => i.COD_NOTA)
                .Select(g => new ItemLivroSaidaResult()
                {
                    CodNota = g.Key!.Value,
                    Numero = g.First().COD_NOTANavigation.NUM_NOTA,
                    Serie = g.First().COD_NOTANavigation.DES_SERIE,
                    DtaEmissao = g.First().COD_NOTANavigation.DTA_EMISSAO,
                    CodOperacaoFiscalCabecalho = g.First().COD_NOTANavigation.COD_OPERACAO_FISCAL,
                    CfopCabecalho = g.First().COD_NOTANavigation!.COD_OPERACAO_FISCALNavigation!.COD_CFOP,
                    CodEmpresa = g.First().COD_NOTANavigation.COD_EMPRESA,
                    Emitente = new ItemLivroSaidaResult.EmitenteModel()
                    {
                        Codigo = g.First().COD_NOTANavigation.COD_PESSOA ?? 0,
                        DesEmitente = g.First().COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA,
                        SiglaUF = g.First().COD_NOTANavigation.COD_PESSOANavigation.PS_ENDERECOS.FirstOrDefault().COD_CIDADENavigation.COD_IBGE_UFNavigation.DES_ABREVIATURA
                    },
                    VlrTotal = g.Sum(i => (i.VLR_MERCADORIA ?? 0) - (i.VLR_DESCONTO ?? 0 + i.VLR_FRETE ?? 0 + i.VLR_SEGURO ?? 0 + i.VLR_ICMS_SUBSTITUTO ?? 0 + i.VLR_ISS ?? 0)) ,
                    IsDevolucao = false,
                    VlrBaseIcms = g.Sum(i => i.VLR_BASE_ICMS ?? 0),
                    VlrIcms = g.Sum(i => i.VLR_ICMS ?? 0),
                    PerIcms = g.Sum(i => i.PER_ICMS ?? 0),
                    VlrIpi = g.Sum(i => i.VLR_IPI ?? 0),
                    VlrBaseIpi = g.Sum(i => i.VLR_BASE_IPI ?? 0),
                    VlrST = g.Sum(i => i.VLR_ICMS_SUBSTITUTO ?? 0),
                    VlrBaseST = g.Sum(i => i.VLR_BASE_ST ?? 0),
                    VlrDesconto = g.Sum(i => i.VLR_DESCONTO ?? 0),
                    VlrOutras = g.Sum(i => 
                        i.VLR_MERCADORIA ?? 0
                        - i.VLR_DESCONTO ?? 0
                        + (i.COD_OPERACAO_FISCALNavigation.TIP_SOMAR_DESPESAS_BASE_ICMS == true ? i.VLR_DESPESAS ?? 0: 0)
                        + i.VLR_SEGURO ?? 0
                        + i.VLR_IPI ?? 0
                        + i.VLR_ICMS_SUBSTITUTO
                    ),
                    Mensagens = g.FirstOrDefault().COD_NOTANavigation.FT_NOTAS_MENSAGENS.Select(m => m.DES_MENSAGEM).ToList(),
                });
        }

        private static IQueryable<ItemLivroSaidaResult> MapToItemLivroSaidaCanceladas(IQueryable<FT_NOTAS_ITENS> queryEntrada)
        {
            return queryEntrada
                .GroupBy(i => i.COD_NOTA)
                .Select(g => new ItemLivroSaidaResult()
                {
                    CodNota = g.Key!.Value,
                    Numero = g.First().COD_NOTANavigation.NUM_NOTA,
                    Serie = g.First().COD_NOTANavigation.DES_SERIE,
                    DtaEmissao = g.First().COD_NOTANavigation.DTA_EMISSAO,
                    CodOperacaoFiscalCabecalho = g.First().COD_NOTANavigation.COD_OPERACAO_FISCAL,
                    CfopCabecalho = g.First().COD_NOTANavigation!.COD_OPERACAO_FISCALNavigation!.COD_CFOP,
                    CodEmpresa = g.First().COD_NOTANavigation.COD_EMPRESA,
                    Emitente = new ItemLivroSaidaResult.EmitenteModel()
                    {
                        Codigo = g.First().COD_NOTANavigation.COD_PESSOA ?? 0,
                        DesEmitente = g.First().COD_NOTANavigation.COD_PESSOANavigation.DES_PESSOA,
                        SiglaUF = g.First().COD_NOTANavigation.COD_PESSOANavigation.PS_ENDERECOS.FirstOrDefault().COD_CIDADENavigation.COD_IBGE_UFNavigation.DES_ABREVIATURA
                    },
                    VlrTotal = 0,
                    VlrBaseIcms =0,
                    VlrIcms = 0,    
                    PerIcms = 0,
                    VlrIpi = 0,
                    VlrBaseIpi = 0,
                    VlrST = 0,
                    VlrBaseST = 0,
                    VlrDesconto = 0,
                    VlrOutras = 0,
                    IsCancelada = true,
                    DesObservacaoCanceladaDenegada = "Cancelada",
                });
        }
    }

    internal static class ErroLivroSaidas
    { 
        public static Error DataInicialObrigatorio => new Error("LivroSaidas.DataInicialObrigatorio", "Data inicial é campo obrigatório");
        public static Error DataFinalObrigatorio => new Error("LivroSaidas.DataFinalObrigatorio", "Data final é campo obrigatório");
    }

}

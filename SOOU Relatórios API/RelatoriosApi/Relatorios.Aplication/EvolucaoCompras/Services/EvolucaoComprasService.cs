using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.EvolucaoCompras.Erro;
using Relatorios.Aplication.EvolucaoCompras.Models;
using Relatorios.Dominio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.EvolucaoCompras.Services
{
    public interface IEvolucaoCompraService
    {
        public Task<Result<EvolucaoComraRelatorioResponse, Error>> EvolucaoCompra(EvolucaoCompraRequest request);
    }

    internal class EvolucaoComprasService : IEvolucaoCompraService
    {
        private readonly IErpRepositorioGenerico _erpRepositorioGenerico;

        public EvolucaoComprasService(IErpRepositorioGenerico erpRepositorioGenerico)
        {
            _erpRepositorioGenerico = erpRepositorioGenerico;
        }

        public async Task<Result<EvolucaoComraRelatorioResponse, Error>> EvolucaoCompra(EvolucaoCompraRequest request)
        {
            if (!request.Meses.HasValue)
                return EvolucaoCompraErro.ErroMeses;



            var dtaFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dtaInicial = dtaFinal.AddMonths(-request.Meses.Value);

            var queryEntradas = _erpRepositorioGenerico.Query<CE_NOTAS_ITENS>();
            queryEntradas = filtrarEntradas(request, dtaInicial, dtaFinal, queryEntradas);

            var queryDevolucoes = _erpRepositorioGenerico.Query<FT_NOTAS_ITENS>();
            queryDevolucoes = filtrarDevolucoesEntradas(request, dtaInicial, dtaFinal, queryDevolucoes);

            var compras = await EvolucaoCompraResponseMapper.MapTo(queryEntradas).ToListAsync();
            var comprasDevolvidas = await EvolucaoCompraResponseMapper.MapTo(queryDevolucoes).ToListAsync();

            var datas = GetDatasMeses(dtaInicial, dtaFinal).ToList();

            var resultado = datas.Select(i =>
            {
                var entradas = compras.FirstOrDefault(c => c.Data == i) ?? new();
                var devolucoes = comprasDevolvidas.FirstOrDefault(c => c.Data == i) ?? new();

                return new EvolucaoCompraResponse()
                {
                    Data = i.Date,
                    Quantidade = entradas.Quantidade - devolucoes.Quantidade,
                    Valor = entradas.Valor - devolucoes.Valor,
                };

            });

            return new EvolucaoComraRelatorioResponse()
            {
                Itens = resultado.ToList()
            };
        }
        private IEnumerable<DateTime> GetDatasMeses(DateTime inicial, DateTime final)
        {
            var dataInicio = new DateTime(inicial.Year, inicial.Month, 1);
            var dataFim = new DateTime(final.Year, final.Month, 1);
            do
            {
                yield return dataInicio;
                dataInicio = dataInicio.AddMonths(1);

            } while (dataInicio < dataFim);
        }

        private static IQueryable<CE_NOTAS_ITENS> filtrarEntradas(EvolucaoCompraRequest request, DateTime dtaInicial, DateTime dtaFinal, IQueryable<CE_NOTAS_ITENS> queryEntradas)
        {
            queryEntradas = queryEntradas
                .Where(i => i.COD_EMPRESA == request.CodEmpresa)
                .Where(i => i.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true)
                .Where(i => i.COD_NOTANavigation.DTA_EMISSAO >= dtaInicial)
                .Where(i => i.COD_NOTANavigation.DTA_EMISSAO < dtaFinal);

            if (request.Marcas.Any())
                queryEntradas = queryEntradas.Where(i => request.Marcas.Contains(i.COD_PRODUTONavigation!.COD_MARCA ?? 0));

            if (request.Categorias.Any())
                queryEntradas = queryEntradas.Where(i => request.Categorias.Contains(i.COD_PRODUTONavigation!.COD_CATEGORIA ?? 0));

            if (request.Classificacoes.Any())
                queryEntradas = queryEntradas.Where(i => request.Classificacoes.Contains(i.COD_PRODUTONavigation!.COD_CLASSIFICACAO ?? 0));

            if (request.Produtos.Any())
                queryEntradas = queryEntradas.Where(i => request.Produtos.Contains(i.COD_PRODUTO ?? 0));

            if(request.Fornecedores.Any())
                queryEntradas = queryEntradas.Where(i => request.Fornecedores.Contains(i.COD_NOTANavigation.COD_PESSOA ?? 0));

            return queryEntradas;
        }

        private static IQueryable<FT_NOTAS_ITENS> filtrarDevolucoesEntradas(EvolucaoCompraRequest request, DateTime dtaInicial, DateTime dtaFinal, IQueryable<FT_NOTAS_ITENS> query)
        {
            
            query = query
                .Where(i => i.COD_NOTANavigation.COD_EMPRESA == request.CodEmpresa)
                .Where(i => i.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_COMPRAS != true)
                .Where(i => i.COD_NOTANavigation.DTA_EMISSAO >= dtaInicial)
                .Where(i => i.COD_NOTANavigation.DTA_EMISSAO < dtaFinal);

            query = query.Where(n => n.FT_DEVOLUCOES.Any(d => d.COD_NOTA_SAIDANavigation.DTA_CANCELAMENTO == null));

            if (request.Marcas.Any())
                query = query.Where(i => request.Marcas.Contains(i.COD_PRODUTONavigation!.COD_MARCA ?? 0));

            if (request.Categorias.Any())
                query = query.Where(i => request.Categorias.Contains(i.COD_PRODUTONavigation!.COD_CATEGORIA ?? 0));

            if (request.Classificacoes.Any())
                query = query.Where(i => request.Classificacoes.Contains(i.COD_PRODUTONavigation!.COD_CLASSIFICACAO ?? 0));

            if (request.Produtos.Any())
                query = query.Where(i => request.Produtos.Contains(i.COD_PRODUTO ?? 0));

            if (request.Fornecedores.Any())
                query = query.Where(n => n.FT_DEVOLUCOES.Any(d => request.Fornecedores.Contains(d.COD_NOTA_ENTRADANavigation.COD_PESSOA ?? 0)));

            return query;
        }

    }

}

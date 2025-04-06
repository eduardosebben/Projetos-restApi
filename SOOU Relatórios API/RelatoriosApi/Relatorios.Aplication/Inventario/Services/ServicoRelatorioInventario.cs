using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Inventario.Services
{
    public interface IServicoRelatorioInventario
    {
        Task<RelatorioInventarioGeralDto> RetornarRelatorioInventario(ConfiguradorRelatorioInventarioDto model);
    }

    public class ServicoRelatorioInventario : IServicoRelatorioInventario
    {
        private readonly IErpRepositorioGenerico _repositorioErp;
        private readonly IRepositorioEmpresasPadrao _repositorioEmpresasPadrao;

        public ServicoRelatorioInventario(
            IErpRepositorioGenerico repositorioErp,
            IRepositorioEmpresasPadrao repositorioEmpresasPadrao)
        {
            _repositorioErp = repositorioErp;
            _repositorioEmpresasPadrao = repositorioEmpresasPadrao;
        }

        public async Task<RelatorioInventarioGeralDto> RetornarRelatorioInventario(ConfiguradorRelatorioInventarioDto filtros)
        {
            if (!filtros.DtaReferencia.HasValue)
                throw new ArgumentException("Campo obrigatório ", nameof(filtros.DtaReferencia));

            if (!filtros.MesAnoReferencia.HasValue)
                throw new ArgumentException("Campo obrigatório ", nameof(filtros.MesAnoReferencia));

            var empresasPadrao = await _repositorioEmpresasPadrao.EmpresasPadraoCollection(filtros.DadosAcesso.CodigoEmpresa);
            var empresaAlmoxarifadoProduto = empresasPadrao[EmpresaPadrao.AlmoxarifadoProduto].CodEmpresaPadrao;
            var empresaValoresProduto = empresasPadrao[EmpresaPadrao.ProdutosValores].CodEmpresaPadrao;
            var empresaPadraoProduto = empresasPadrao[EmpresaPadrao.Produtos].CodEmpresaPadrao;

            var queryProdutos = _repositorioErp.Query<CE_PRODUTOS>().Where(x => x.COD_EMPRESA == empresaPadraoProduto && x.TIP_SERVICO == false);

            var parametrosEstoque = _repositorioErp.Query<CE_PARAMETROS>().FirstOrDefault(x => x.COD_EMPRESA == filtros.DadosAcesso.CodigoEmpresa) ?? new CE_PARAMETROS();

            if (!filtros.TipProdutosDesativados)
                queryProdutos = queryProdutos.Where(p => p.DTA_DESATIVACAO == null || p.DTA_DESATIVACAO > filtros.DtaReferencia);

            if (!string.IsNullOrEmpty(filtros.Filtros.CodSku))
                queryProdutos = queryProdutos.Where(p => p.COD_PRODUTO_EMPRESA.ToLower() == filtros.Filtros.CodSku);

            if (!string.IsNullOrEmpty(filtros.Filtros.DesProduto))
                queryProdutos = queryProdutos.Where(p => p.DES_PRODUTO.ToLower().Contains(filtros.Filtros.DesProduto));

            if (filtros.Filtros.ListaMarcas.Any())
                queryProdutos = queryProdutos.Where(p => p.COD_MARCA != null && filtros.Filtros.ListaMarcas.Contains(p.COD_MARCA!.Value));

            if (filtros.Filtros.ListaCategorias.Any())
                queryProdutos = queryProdutos.Where(p => p.COD_CATEGORIA != null && filtros.Filtros.ListaCategorias.Contains(p.COD_CATEGORIA!.Value));

            if (parametrosEstoque?.TIP_VALIDAR_PRODUTOS_VENDA == true)
            {
                queryProdutos = queryProdutos.Where(x => x.CE_PRODUTOS_VENDAS_EMPRESAS.Any(y => y.COD_EMPRESA == filtros.DadosAcesso.CodigoEmpresa));
            }

            if (filtros.Filtros.ListaAlmoxarifados.Any())
                queryProdutos = queryProdutos.Where(p =>
                    p.CE_PRODUTO_ALMOXARIFADOS
                        .Where(a => a.COD_EMPRESA == empresaAlmoxarifadoProduto).Select(x => x.COD_ALMOXARIFADO).Any(c => filtros.Filtros.ListaAlmoxarifados.Contains(c!.Value)));

            if (filtros.Filtros.ListaClassificacoesFiscais.Any())
                queryProdutos = queryProdutos.Where(p => p.COD_CLASSIFICACAO_FISCAL != null && filtros.Filtros.ListaClassificacoesFiscais.Contains(p.COD_CLASSIFICACAO_FISCAL!.Value));

            var queryMovimentos = _repositorioErp.Query<CE_MOVIMENTOS_ESTOQUES>().Where(x => x.COD_EMPRESA == filtros.DadosAcesso.CodigoEmpresa);

            var marcasNaoListar = _repositorioErp.Query<GE_MARCAS>()
                .Where(x => x.COD_EMPRESA == empresaPadraoProduto && x.TIP_NAO_LISTAR_INVENTARIO == true)
                .Select(m => m.COD_MARCA).ToList();
            if (!marcasNaoListar.IsNullOrEmpty())
                queryProdutos = queryProdutos.Where(p => !marcasNaoListar.Contains(p.COD_MARCA.Value));

            var categoriasNaoListar = _repositorioErp.Query<GE_CATEGORIAS_PRODUTOS>()
                .Where(x => x.COD_EMPRESA == empresaPadraoProduto && x.TIP_NAO_LISTAR_INVENTARIO == true)
                .Select(c => c.COD_CATEGORIA).ToList();
            if (!categoriasNaoListar.IsNullOrEmpty())
                queryProdutos = queryProdutos.Where(p => !categoriasNaoListar.Contains(p.COD_CATEGORIA.Value));

            var classifProdutosNaoListar = _repositorioErp.Query<GE_CLASSIFICACOES_PRODUTOS>()
                .Where(x => x.COD_EMPRESA == empresaPadraoProduto && x.TIP_NAO_LISTAR_INVENTARIO == true)
                .Select(m => m.COD_CLASSIFICACAO).ToList();
            if (!classifProdutosNaoListar.IsNullOrEmpty())
                queryProdutos = queryProdutos.Where(p => !classifProdutosNaoListar.Contains(p.COD_CLASSIFICACAO.Value));

            //pega os movimentos no periodo dos produtos filtrados
            var dtaFiltroReferencia = filtros.DtaReferencia.Value.AddDays(1).Date;
            queryMovimentos = queryMovimentos
                .Where(x => x.DTA_MOVIMENTO <= dtaFiltroReferencia)
                .Where(x => queryProdutos.Any(p => p.COD_PRODUTO == x.COD_PRODUTO));

            var filtroAlmoxarifados = filtros.Filtros.ListaAlmoxarifados.ToArray();
            if (filtros.Filtros.ListaAlmoxarifados.Any())
                queryMovimentos = queryMovimentos
                    .Where(movimento => movimento.COD_PRODUTO_ALMOXARIFADONavigation.COD_ALMOXARIFADO != null && filtroAlmoxarifados.Contains(movimento.COD_PRODUTO_ALMOXARIFADONavigation.COD_ALMOXARIFADO.Value));

            queryMovimentos = queryMovimentos.Where(movimento => movimento.COD_PRODUTONavigation != null && movimento.COD_PRODUTONavigation.TIP_NAO_LISTAR_INVENTARIO != true && movimento.COD_PRODUTO_ALMOXARIFADONavigation.TIP_EXCLUIDO != true);

            var ultimosMovimentosProdutos = queryMovimentos
                .Select(m => new
                {
                    m.COD_PRODUTO,
                    m.COD_PRODUTO_ALMOXARIFADO,
                    m.COD_PRODUTO_ALMOXARIFADONavigation.COD_ALMOXARIFADO,
                    m.VLR_CUSTO_MEDIO,
                    m.VLR_CUSTO_REAL,
                    m.DTA_MOVIMENTO,
                    m.QTD_ESTOQUE_ATUAL
                })
                .GroupBy(x => new { x.COD_PRODUTO, x.COD_PRODUTO_ALMOXARIFADO })
                .Select(x => x.OrderByDescending(y => y.DTA_MOVIMENTO).FirstOrDefault())
                .ToList();

            ultimosMovimentosProdutos = ultimosMovimentosProdutos.OrderByDescending(x => x.DTA_MOVIMENTO).ToList();
                     
            var produtosUltimosMovimentos = queryProdutos
              .SelectMany(produto => produto.CE_PRODUTO_ALMOXARIFADOS)
              .Where(x => x.COD_EMPRESA == empresaAlmoxarifadoProduto)
              .Select(produtoAlmoxarifado => new
              {
                  produto = produtoAlmoxarifado.COD_PRODUTONavigation,
                  codProduto = produtoAlmoxarifado.COD_PRODUTO,
                  codSku = produtoAlmoxarifado.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA,
                  desClassificacaoFiscal = produtoAlmoxarifado.COD_PRODUTONavigation.COD_CLASSIFICACAO_FISCALNavigation.DES_CLASSIFICACAO_FISCAL,
                  desProduto = produtoAlmoxarifado.COD_PRODUTONavigation.DES_PRODUTO,
                  desUnidadeMedida = produtoAlmoxarifado.COD_PRODUTONavigation.COD_UNIDADE_MEDIDANavigation.DES_UNIDADE_MEDIDA,
                  codUnidadeMedida = produtoAlmoxarifado.COD_PRODUTONavigation.COD_UNIDADE_MEDIDA,
                  numCasasDecimaisUnidadeMedida = produtoAlmoxarifado.COD_PRODUTONavigation.COD_UNIDADE_MEDIDANavigation.NUM_CASAS_DECIMAIS,

                  valoresProduto = produtoAlmoxarifado.COD_PRODUTONavigation.CE_PRODUTOS_VALORES.FirstOrDefault(v => v.COD_EMPRESA == empresaValoresProduto),

                  codProdutoAlmoxarifado = produtoAlmoxarifado.COD_PRODUTO_ALMOXARIFADO,
                  codAlmoxarifado = produtoAlmoxarifado.COD_ALMOXARIFADO,
                  desAlmoxarifado = produtoAlmoxarifado.COD_ALMOXARIFADONavigation.DES_ALMOXARIFADO
              });

            if (filtros.Filtros.ListaAlmoxarifados.Any())
                produtosUltimosMovimentos = produtosUltimosMovimentos.Where(x => filtros.Filtros.ListaAlmoxarifados.Contains(x.codAlmoxarifado ?? -1));

            var almoxarifadosNaoListar = _repositorioErp.Query<GE_ALMOXARIFADOS>()
                .Where(x => x.COD_EMPRESA == empresaPadraoProduto && x.TIP_NAO_LISTAR_INVENTARIO == true)
                .Select(a => a.COD_ALMOXARIFADO).ToList();

            if (almoxarifadosNaoListar.Any())
                produtosUltimosMovimentos = produtosUltimosMovimentos
                    .Where(movimento => !almoxarifadosNaoListar.Contains(movimento.codAlmoxarifado.Value));

            var produtos = produtosUltimosMovimentos.ToList().Select(x =>
                {
                    var valor = filtros.IndCampoValor == CampoValor.CustoMedio
                        ? (x.valoresProduto?.VLR_CUSTO_MEDIO ?? 0)
                        : (x.valoresProduto?.VLR_CUSTO_REAL ?? 0);

                    var ultimoMovimento = ultimosMovimentosProdutos.FirstOrDefault(movimento =>
                        movimento.COD_PRODUTO == x.produto.COD_PRODUTO
                        && movimento.COD_PRODUTO_ALMOXARIFADO == x.codProdutoAlmoxarifado
                        && movimento.COD_ALMOXARIFADO == x.codAlmoxarifado);

                    return new RelatorioInventarioDto.ProdutosModel()
                    {
                        CodSku = x.codSku,
                        CodProduto = x.codProduto,
                        DesClassificacaoFiscal = x.desClassificacaoFiscal,
                        DesProduto = x.desProduto,
                        DesUnidadeMedida = x.desUnidadeMedida,
                        CodUnidadeMedida = x.codUnidadeMedida,
                        NumCasasDecimaisUnidadeMedida = x.numCasasDecimaisUnidadeMedida,
                        Valor = (filtros.IndCampoValor == CampoValor.CustoMedio ? ultimoMovimento?.VLR_CUSTO_MEDIO : ultimoMovimento?.VLR_CUSTO_REAL) ?? valor,
                        Almoxarifado = x.desAlmoxarifado,
                        QuantidadeEstoque = ultimoMovimento?.QTD_ESTOQUE_ATUAL ?? 0
                    };
                }).ToList();

            if (!filtros.TipListarComEstoqueNegativo)
                produtos = produtos.Where(x => x.QuantidadeEstoque > 0).ToList();


            if (filtros.TipListarApenasComQtdeEstoque)
                produtos = produtos.Where(x => x.QuantidadeEstoque > 0).ToList();

            var relatorio = new RelatorioInventarioDto(filtros);
            relatorio.Produtos = produtos;
            relatorio.Produtos = relatorio.Produtos.OrderBy(x => x.DesProduto);

            if (filtros.IndOrdem == 1)
                relatorio.Produtos = relatorio.Produtos.OrderBy(x => x.CodSku);

            return new RelatorioInventarioGeralDto(relatorio, filtros);
        }
    }




}

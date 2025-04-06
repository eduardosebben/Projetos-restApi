using BoletoNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceNetCore;
using EcommerceApi.Models;
using EcommerceNetCore.Models;

namespace BoletoApiCore.Extensions
{
    public class MetodosConsultar
    {
        private LogarDtoResponse logar;

        public MetodosConsultar(LogarDtoResponse logarDto)
        {
            logar = logarDto;
        }
        #region Publicacao e Republicacao Itens
        public string RetornarConsultaDetalhesProduto(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };
            var teste = "items/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaCategoria(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaGarantiaProduto(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaCondicao(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #region Tipos Publicacao
        public string RetornarConsultaTipoAnuncioSite(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_types";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaEspecificacoesTipoAnuncio(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_types/" + dados.tipoLista;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaTempoAnuncio(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };
            var complemento = "items/" + dados.itemID + "?attributes=stop_time";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAnunciosDisponiveis(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.custoID + "/available_listing_types?category_id=" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaErroPublicarAnuncios(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.custoID + "/available_listing_types/free?category_id=" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaExposicaoPublicacao(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_exposures";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaExposicaoPublicacaoID(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_exposures/" + dados.exposicaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAtualizacoesDisponiveis(DadosConsultaTipoPublicacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/available_upgrades";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Categorizacao
        public string RetornarConsultaProdutos(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/domain_discovery/search?limit=1&q=" + dados.complementoProduto;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCategoriasPorSite(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/categories";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesCategoria(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "categories/" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCompatibilidadeEntreDominios(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog/dumps/domains/MLB/compatibilities";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaValoresPossiveisRestricaoPosicao(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_compatibilities/restrictions/values?main_domain_id="+ dados.dominioIDUm + "&secondary_domain_id=" + dados.dominioIDDois;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCompatibilidadesItem(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/compatibilities?extended=true";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCompatibilidadesID(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/compatibilities/" + dados.compatibilidadeID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotaCompatibilidade(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/compatibilities/" + dados.compatibilidadeID + "/note";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItemEmExcecao(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/compatibilities/exception";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAtributosCategoria(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "categories/" + dados.categoriaID + "/attributes";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAtributosDominio(DadosCategorizacaoProdutos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_domains/" + dados.dominioIDUm ;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Descricao Itens 
        public string RetornarConsultaDescricaoItem(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/description";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Imagens
        public string RetornarConsultaErrosImagens(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "pictures/" + dados.imagemID + "/errors";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Precos e Custos
        public string RetornarConsultaPrecosVendas(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/sale_price?context="+ dados.canalVendas + "," + dados.nivelComprador;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPrecoProduto(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/prices";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPrecoMoeda(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_prices?price=" + dados.preco + "&cy_id=" + dados.currencyID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPrecoListingType(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_prices?price=" + dados.preco + "&listing_type_id=" + dados.tipoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPrecoPorCategoria(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_prices?price=" + dados.preco + "&category_id=" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaTipoPublicacaoCategoria(DadosPrecosCustos dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/listing_prices/" + dados.tipoID + "?price=" + dados.preco + "&category_id=" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Identificadores Produtos
        public string RetornarConsultaGTIN(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "?include_attributes=all";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Variacao
        public string RetornarConsultaProdutosVariacao(DadosVariacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "categories/" + dados.categoriaID + "/attributes";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVariacoes(DadosVariacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/variations";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVariacaoID(DadosVariacao dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "items/" + dados.itemID + "/variations/" + dados.variacaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
        #region Tabela de medidas
        public string RetornarConsultaDominiosDisponiveisMedidas(DadosTabelaMedidas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog/charts/MLB/configurations/active_domains";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaFichaTecnicaDominio(DadosTabelaMedidas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "domains/" + dados.dominioID + "/technical_specs";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaTabelaMedidasdados(DadosTabelaMedidas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog/charts/" + dados.graficoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPublicacaoStatusCetificado(DadosTabelaMedidas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "picture-certifier/integrator/items?sellerId=" + dados.vendedorID + "&categoryId=" + dados.categoriaID + "&status=" + dados.status + "&offset=0&limit=500";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaImagemItem(DadosTabelaMedidas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "picture-certifier/integrator/items/" + dados.itemID + "/status?locale=" + dados.local + "&sellerId=" + dados.vendedorID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #endregion
        #region Sincronização e Modificação de Publicações
        public string RetornarConsultaTempoDisponibilidadeEstoque(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "categories/" + dados.categoriaID + "/sale_terms";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaQuantidadeMaximaCompra(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "categories/" + dados.categoriaID + "/sale_terms";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
        #region Modos de Envio
        public string RetornarConsultaModoEnvioPais(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaModosHabilitados(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPreferenciasEnvioUsuario(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPedidosME1(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaRemessaPedido(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaCategoriaMercadoEnvios(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaEtiquetasPDF(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaEtiquetasZPL(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPedidoID(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaOpcoesPedido(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPreçoFreteCEP(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPrecoFreteIDCidade(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaTempoEntrega(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaCapacidadeVenda(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaTempoMinimoPedido(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaHorariosDespacho(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPontosFacultativos(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaOpcoesEnvio(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPontosFacultativosData(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaPontosFacultativosVendedor(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaProdutosFreteGratis(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaFlexItem(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaCodigoIntegradador(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
        #region Catalogo
        public string RetornarConsultaCatalogoItensVendedor(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items/search?catalog_listing=true";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensVendedorSemCatalogo(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items/search?catalog_listing=false";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCatalogoItensVendedorElegibilidade(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items/search?tags=catalog_listing_eligible";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCatalogoListaElegibilidade(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/catalog_listing_eligibility";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMultiplasPublicacoes(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };
            var itens = "";
            foreach(var item in dados.itensID)
            {
                if (string.IsNullOrEmpty(itens))
                    itens = item;
                else
                    itens = itens + "," + item;
            }
            var complemento = "multiget/catalog_listing_eligibility?ids=" + itens;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesProdutoDescricao(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/search?status=" + dados.statusID + "&site_id=MLB&q=" + dados.descricaoProduto;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesProdutoDominio(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/search?status=" + dados.statusID + "&site_id=MLB&q=" + dados.descricaoProduto + "&domain_id=" + dados.dominioID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesProdutoID(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/search?status=" + dados.statusID + "&site_id=MLB&product_identifier=" + dados.produtoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesProduto(DadosCatalogo dados)
        {
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/" + dados.produtoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaProdutoParaPublicar(DadosCatalogo dados)
        {
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaProdutoCriacaoAutomaticaItens(DadosCatalogo dados)
        {
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaProdutoPreviamente(DadosCatalogo dados)
        {
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/search?status=active&site_id=MLB&listing_strategy=catalog_required&q=" + dados.descricaoProduto;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCatalogoItensAvisoPrevio(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items/search?tags=catalog_forewarning";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCatalogoItensAvisoPrevioData(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/catalog_forewarning/date";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaInfracoes(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "moderations/infractions/" + dados.usuarioID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesPublicacaoConcorencia(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/price_to_win?MLB&version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPublicacoesPDP(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/" + dados.produtoID + "/items";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPublicacoesPDPFiltros(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "products/" + dados.produtoID + "/items?" + dados.descricaoFiltro;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultSugestoesUsuario(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_suggestions/users/" + dados.usuarioID + "/quota";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDominiodDisponiveis(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_suggestions/domains/MLB/available/full";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaFichaTecnicaDominioCatalogo(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "domains/" + dados.dominioID + "/techincal_specs?channel_id=catalog_suggestions";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaFichaTecnicaSugestoes(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "domains/" + dados.dominioID + "/techincal_specs/input?channel_id=catalog_suggestions";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaSugestaoID(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_suggestions/" + dados.sugestaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaResultadoValidacoes(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_suggestions/" + dados.sugestaoID + "/validations";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaSugestoes(DadosCatalogo dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "catalog_suggestions/users/" + dados.usuarioID + "/suggestions/search";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
        #region Estoque Fulfillment
        public string RetornarConsultaEstoqueFulfillment(DadosEstoqueFulfillment dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "inventories/" + dados.categoriaID + "/stock/fulfillment";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaDetalhesEstoqueNaoDisponvel(DadosEstoqueFulfillment dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "inventories/" + dados.inventarioID + "/stock/fulfillment?include_attributes=conditions";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaReceberNotificacoesEstoque(DadosEstoqueFulfillment dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "stock/fulfillment/operations/search?seller_id=" + dados.vendedorID + "&inventory_id=" + dados.inventarioID + "&date_from=" + dados.dataInicial + "&date_to=" + dados.dataFinal;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaOperacoesID(DadosEstoqueFulfillment dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "stock/fulfillment/operations/" + dados.operacaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
        #region Gerencie Promoções
        public string RetornarConsultaPromocoesVendedor(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/users/" + dados.usuarioID + "?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCandidatos(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/candidates?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItemCandidatoID(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/candidates/" + dados.canditadoID + "?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaOfertas(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/offers?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaOfertaID(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/offers/" + dados.ofertaID + "?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesPromocao(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=" + dados.tipoPromocao + "&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensPromocao(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=" + dados.tipoPromocao + "&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensPromocaoFiltro(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=" + dados.tipoPromocao + "&status=" + dados.status + "&item_id=" + dados.itemID + "&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensPromocaoPaginacao(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=" + dados.tipoPromocao + "&searchAfter=" + dados.itemID + "&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPromocaoItens(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/items/" + dados.itemID + "?app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #region Campanhas Normal
        public string RetornarConsultaDetalhesCampanha(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=DEAL&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCampanha(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=DEAL&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Campanhas Co-participação
        public string RetornarConsultaDetalhesCampanhaCoparticipacao(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=MARKETPLACE_CAMPAIGN&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCampanhaCoparticipacao(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=MARKETPLACE_CAMPAIGN&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Campanhas de Desconto por Volume
        public string RetornarConsultaDetalhesCampanhaDescontoVolume(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=VOLUME&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCampanhaDescontoVolume(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=VOLUME&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Desconto Pré-Acordado por Item
        public string RetornarConsultaDetalhesCampanhaPreAcordo(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=PRE_NEGOTIATED&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarItensCampanhaPreAcordo(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=PRE_NEGOTIATED&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Ofertas do Dia
        public string RetornarConsultaItensCampanhaOfertaDia(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=DOD&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Ofertas Relâmpago
        public string RetornarConsultaItensCampanhaOfertaRelampago(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?app_version=v2&promotion_type=LIGHTNING";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Campanhas do Vendedor
        public string RetornarConsultaDetalhesCampanhaVendedor(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=SELLER_CAMPAIGN&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCampanhaVendedor(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=SELLER_CAMPAIGN&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Campanhas Smart
        public string RetornarDetalhesCampanhaSmart(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "?promotion_type=SMART&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensCampanhaSmart(DadosPromocoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "seller-promotions/promotions/" + dados.promocaoID + "/items?promotion_type=SMART&app_version=v2";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #endregion
        #region Perguntas e Respostas
        public string RetornarPerguntasRecebidasVendedor(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "questions/search?seller_id=" + dados.vendedorID + "&api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPerguntasRecebidasProduto(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "questions/search?item=" + dados.itemID + "&api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarPerguntasRecebidasProdutoSortFields(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "questions/search?seller_id=" + dados.vendedorID + "&sort_fields=" + dados.itemID + "," + dados.dataCriacao + "&api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPerguntasRecebidasProdutoSortTypes(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "search?seller_id=" + dados.vendedorID + "&sort_fields=" + dados.itemID + "," + dados.dataCriacao + "&sort_types=ASC&api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPerguntasFeitasUsuarioProduto(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "questions/search?item=" + dados.itemID + "&from=" + dados.custoID + "&api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPerguntasId(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "questions/" + dados.questaoID + "?api_version=4";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCalculaTempoResposta(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/questions/response_time";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaUsuariosBloqueados(DadosPerguntasRespostas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.vendedorID + "/questions_blacklist";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Gerencie Vendas
        public string RetornarConsultaNovaVenda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.ordemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaConversaoMoeda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "currency_conversions/search?from=" + dados.currencyIDIni + "&to=" + dados.CurrencyIDFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaProdutosMesmaVenda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.ordemID + "/product";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendas(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasFiltros(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };
            var complemento = "";
            if (!string.IsNullOrEmpty(dados.status))
                complemento = "orders/search?seller=" + dados.vendedorID + "&order.status=" + dados.status;
            if (!string.IsNullOrEmpty(dados.vendedorIni))
                complemento = "orders/search?seller=" + dados.vendedorIni + "&q=" + dados.vendedorFim;
            if (!string.IsNullOrEmpty(dados.dataCriacaoIni))
                //date_last_updated
                complemento = "orders/search?seller=" + dados.vendedorID + "&order.date_created.from=" + dados.dataCriacaoIni + "&order.date_created.to=" + dados.dataCriacaoFim;

            complemento = $"{complemento}&search_type=scan";
            if (!string.IsNullOrEmpty(dados.scrollID))
                complemento = $"{complemento}&scroll_id={dados.scrollID}";

            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasOrdenacao(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search?seller=" + dados.vendedorID + "&order.status=paid&sort=date_desc";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasRecentes(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search/recent?seller=" + dados.vendedorID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasPendentes(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search/pending?seller=" + dados.vendedorID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasArquivadas(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search/archived?seller=" + dados.vendedorID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasArquivadasComprador(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/search/archived?seller=" + dados.CompradorID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendaOpcoes(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/order_id?options";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVendasCarrinho(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "packs/" + dados.pacoteID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaEnvios(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaItensEnvio(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/items";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaCustosEnvio(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/costs";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPagamentosEnvio(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/payments";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaProzoEntrega(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/lead_time";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaEnviosAtrasados(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/delays";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaHistoricoPedido(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/history";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaUrlRastreio(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/carrier";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaStatusSubstaus(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipment_statuses";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaFeedbackVenda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.ordemID + "/feedback";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaFeedBackIDVenda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "feedback/" + dados.feedbackID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotasVenda(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.ordemID + "/notes";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaUsuariosBloqueadosVendas(DadosGerencieVendas dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.custoID + "/order_blacklist";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Faturador Mercado Livre
        public string RetornarConsultaItensVendedor(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items/search";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaErrosEmissaoNota(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/invoices/errors/MLB/" + dados.codErro;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaRegrasTributrias(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/tax_rules";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaRegraTributariaID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/tax_rules/" + dados.regraID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensTributacao(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/tax_rules/messages";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensTributacaoID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/tax_rules/messages/" + dados.mensagemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDadosFiscaisSKU(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/fiscal_information/" + dados.SKU;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDadosFiscaisItem(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/fiscal_information/detail";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPublicacaoPodeSerFaturada(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "can_invoice/items/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVariacaoID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "can_invoice/items/" + dados.variacaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaInscricaoEstadualCNPJ(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/state_registry/" + dados.CNPJ;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaInscricaoEstadualCNPJEstado(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/state_registry/" + dados.CNPJ + "/" + dados.estado;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaXMLNota(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/documents/xml/" + dados.notaID + "/authorized";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaStatusNotaInvoiceID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/" + dados.invoiceID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaStatusNotaOrderID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/orders/" + dados.ordemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaStatusRemessaInvoiceID(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/shipments/" + dados.remessaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotasMes(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/sites/MLB/batch_request/period/" + dados.dataIni;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotasPeriodo(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/sites/MLB/batch_request/period/stream?start=" + dados.dataIni + "&end=" + dados.dataFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotasFiltrosCTE(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/sites/MLB/batch_request/period/stream?start=" + dados.dataIni + "&end=" + dados.dataFim + "&sale=all&return=all&full=all&others=all&file_types=xml,pdf&simple_folder=false";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensCadastrada(DadosFaturador dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/invoices/fiscal_rules/v2/additional-messages";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Relatório Faturamento
        public string RetornarConsultaFaturamentoPeriodo(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/documents?group=" + dados.grupo + "&document_type=BILL&limit=1";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaResumoFaturamento(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/summary";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesConciliacao(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/group/" + dados.grupo + "/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesCobrancaMercadoPago(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/group/" + dados.grupo + "/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesCobrancaMercadoEnvioFlex(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/group/" + dados.grupo + "/flex/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesCobrancaFulfillment(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/group/" + dados.grupo + "/full/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesEncargosBonificacaoGarantia(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "integration/periods/" + dados.dataPeriodo + "/group/" + dados.grupo + "/insurtech/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarDownloadDocumentoLegal(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/legal_document/" + dados.fileID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaEstadoCriacaoRelatorio(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/reports/" + dados.fileID + "/status";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarDownLoadRelatorio(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/reports/" + dados.fileID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaResumoPercepcoes(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/periods/" + dados.dataPeriodo + "/perceptions/summary";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesPercepcao(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/group/" + dados.grupo + "/perceptions/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesPercepcaoMercadoPagado(DadosRelatorioFaturamento dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "billing/integration/group/" + dados.grupo + "/perceptions/details";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Enviar Nota Fiscal
        public string RetornarConsultaDadosFaturamento(DadosEnviarNotaFiscal dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.ordemID + "/billing_info";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaBillingInfo(DadosEnviarNotaFiscal dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "orders/" + dados.remessaID + "/billing_info";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNotaFiscalEnviada(DadosEnviarNotaFiscal dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "shipments/" + dados.remessaID + "/invoice_data?siteId=MLB";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string EnviarXmlMercadoLivre(DadosEnviarNotaFiscal dados, string xml)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "packs/" + dados.ordemID + "/invoice_data/?siteId=MLB";
            var conectaEcommerce = new ConectaEcommerce();
            return "";// conectaEcommerce.Enviar(complemento, logarDto);
        }
        public string RetornarConsultaIDsNF(DadosEnviarNotaFiscal dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "packs/" + dados.pacoteID +  "/fiscal_documents";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaNF(DadosEnviarNotaFiscal dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "packs/" + dados.pacoteID + "/fiscal_documents/" + dados.notaFiscalID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Mensagens Pós Venda
        public string RetornarConsultaOpcoesComunicacaoDisponiveis(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/action_guide/packs/" + dados.pacoteID + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaQtdDisponivelMensagens(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/action_guide/packs/" + dados.pacoteID + "/caps_available?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensPacote(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/packs/" + dados.pacoteID + "/sellers/" + dados.usuarioID + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensID(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/" + dados.mensagemID + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAnexosMensagem(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/attachments/" + dados.anexoID + "?tag=post_sale&site_id=MLB";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensPendentes(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/unread/" + dados.recurso + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensPendentesVendedor(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/unread?role=" + dados.papel + "&tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensLidas(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/packs/" + dados.pacoteID + "/sellers/" + dados.vendedorID + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensNaoLidas(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/unread?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensBloqueadas(DadosMensagensPosVenda dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "messages/packs/" + dados.pacoteID + "/sellers/" + dados.vendedorID + "?tag=post_sale";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Métricas e Tendências 
        public string RetornarConsultaOpinioesProduto(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "reviews/item/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaOpnioesCatalogoProdutos(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "reviews/item/" + dados.itemID + "?catalog_product_id=" + dados.catalogoProdutoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaReputacaoVendedores(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaTendenciasPais(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "trends/MLB";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaTendenciasPaisCategoria(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "trends/$SITE_ID/" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaQualidadePublicacoesPais(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "sites/MLB/health_levels";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesQualidadeItem(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/health";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaAcoesQualidadeItem(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/health/actions";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMaisVendidosCategoria(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "highlights/MLB/category/" + dados.categoriaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMaisVendidosCategoriaMarca(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "highlights/MLB/category/" + dados.categoriaID + "?attribute=BRAND&attributeValue=" + dados.atributo;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPosicionamentoProduto(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "highlights/MLB/product/" + dados.produtoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaPosicionamentoItem(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "highlights/MLB/item/" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVisitasUsuario(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items_visits?date_from=" + dados.dataIni + "&date_to=" + dados.dataFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVisitasAnuncio(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "visits/items?ids=" + dados.itemID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVisitasAnuncioData(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/visits?ids=" + dados.itemID + "&date_from=" + dados.dataIni + "&date_to=" + dados.dataFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVisitasAnuncioDataUsuario(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "users/" + dados.usuarioID + "/items_visits/time_window?last=2&unit=" + dados.dataFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaVisitasDataAnuncio(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "items/" + dados.itemID + "/visits/time_window?last=2&unit=day&ending=" + dados.dataFim;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaStatusVendedor(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_quality/status?seller_id=" + dados.vendedorID + "&include_items=" + dados.incluirItens + "&v=" + dados.versao;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaQualidadeAnuncio(MetricasTendencias dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "catalog_quality/status?item_id=" + dados.itemID + "&v=3";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Reclamações Devoluções
        public string RetornarConsultaReclamacoes(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/search?stage=dispute";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaReclamacoesFiltros(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/search?stage=dispute&status=" + dados.status + "&range=date_created:after:" + dados.dataIni + ",before:" + dados.dataFim + "&sort:desc";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaReclamacoesOrdenecacao(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/search?stage=dispute&status=" + dados.status + "&sort=last_updated:asc";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDetalhesReclamacao(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaMensagensREclamacao(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/messages";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaArquivosReclamacoes(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/attachments/" + dados.anexoID + "/download";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaInformacoesArquivo(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/attachments/" + dados.anexoID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaResolucaoEsperadas(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/expected_resolutions";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaEvidenciasReclamacao(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/evidences";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaHistoricoAcoesReclamacao(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v1/claims/" + dados.reclamacaoID + "/status_history";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        public string RetornarConsultaDevolucoes(DadosReclamacoesDevolucoes dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var complemento = "v2/claims/" + dados.reclamacaoID + "/returns";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(complemento, logarDto);
        }
        #endregion
        #region Mercado Lider Lojas Oficiais
        public string RetornarConsultaMarcas(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "users/" + dados.usuarioID + "/brands";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        public string RetornarConsultaMarcasID(DadosConsulta dados)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dados.logar.ClientId,
                ClientSecret = dados.logar.ClientSecret,
                code = dados.logar.code,
                codeVerifier = dados.logar.codeVerifier,
                Username = dados.logar.Username,
                Password = dados.logar.Password,
                IndAmbiente = dados.logar.IndAmbiente,
                type = dados.logar.type,
                urlRetorno = dados.logar.urlRetorno
            };

            var teste = "users/58715193/brands/" + dados.marcaID;
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Consulta(teste, logarDto);
        }
        #endregion
    }
}

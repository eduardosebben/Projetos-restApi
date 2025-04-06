using BoletoApiCore.Extensions;
using BoletoNetCore.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]   
    public class MercadoLivreApiController : ControllerBase
    {
        MetodosUteis metodosUteis = new MetodosUteis();

        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
        #region Publicacao e Republicacao Itens
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesProduto")]
        public IActionResult GetConsultaDetalhesProduto(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesProduto(dados);

            return Ok(htmlBoleto);
        }

        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCategoria")]
        public IActionResult GetConsultaDetalhesCategoria(DadosConsulta dados)
        {
            //teste de build
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCategoria(dados);

            return Ok(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCondicao")]
        public IActionResult GetConsultaDetalhesCondicao(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCondicao(dados);

            return Ok(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaGarantiaProduto")]
        public IActionResult GetConsultaGarantiaProduto(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaGarantiaProduto(dados);

            return Ok(htmlBoleto);
        }
        #endregion
        #region Tipos Publicacao
        //!!!!!!!!!!!!!!!!!!!!!!!! Tipos de Publiação !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTipoAnuncioSite")]
        public async Task<IActionResult> ConsultaTipoAnuncioSite(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTipoAnuncioSite(dados);

            return Content(htmlBoleto);
        }

        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEspecificacoesTipoAnuncio")]
        public async Task<IActionResult> GetConsultaEspecificacoesTipoAnuncio(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEspecificacoesTipoAnuncio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTempoAnuncio")]
        public async Task<IActionResult> GetConsultaTempoAnuncio(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTempoAnuncio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAnunciosDisponiveis")]
        public async Task<IActionResult> GetConsultaAnunciosDisponiveis(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAnunciosDisponiveis(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaErroPublicarAnuncios")]
        public async Task<IActionResult> GetConsultaErroPublicarAnuncios(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaErroPublicarAnuncios(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaExposicaoPublicacao")]
        public async Task<IActionResult> GetExposicaoPublicacao(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaExposicaoPublicacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaExposicaoPublicacaoID")]
        public async Task<IActionResult> GetExposicaoPublicacaoID(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaExposicaoPublicacaoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsultaTipoPublicacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAtualizacoesDisponiveis")]
        public async Task<IActionResult> GetConsultaAtualizacoesDisponiveis(DadosConsultaTipoPublicacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAtualizacoesDisponiveis(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Categorizacao
        //!!!!!!!!!!!!!!!!!!!!! Categorização !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutos")]
        public async Task<IActionResult> GetConsultaProdutos(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutos(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCategoriasPorSite")]
        public async Task<IActionResult> ConsultaCategoriasPorSite(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCategoriasPorSite(dados);

            return Content(htmlBoleto);
        }

        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCategoria")]
        public async Task<IActionResult> ConsultaDetalhesCategoria(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCategoria(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCompatibilidadeEntreDominios")]
        public async Task<IActionResult> ConsultaCompatibilidadeEntreDominios(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCompatibilidadeEntreDominios(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaValoresPossiveisRestricaoPosicao")]
        public async Task<IActionResult> ConsultaValoresPossiveisRestricaoPosicao(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaValoresPossiveisRestricaoPosicao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCompatibilidadesItem")]
        public async Task<IActionResult> ConsultaCompatibilidadesItem(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCompatibilidadesItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCompatibilidadesID")]
        public async Task<IActionResult> GetConsultaCompatibilidadesID(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCompatibilidadesID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotaCompatibilidade")]
        public async Task<IActionResult> GetConsultaNotaCompatibilidade(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotaCompatibilidade(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItemEmExcecao")]
        public async Task<IActionResult> GetConsultaItemEmExcecao(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItemEmExcecao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAtributosCategoria")]
        public async Task<IActionResult> GetConsultaAtributosCategoria(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAtributosCategoria(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCategorizacaoProdutos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAtributosDominio")]
        public async Task<IActionResult> GetConsultaAtributosDominio(DadosCategorizacaoProdutos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAtributosDominio(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Descricao Itens 
        //!!!!!!!!!!!!!!!!!!!!!! Descrição Itens !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDescricaoItem")]
        public async Task<IActionResult> GetConsultaDescricaoItem(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDescricaoItem(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Imagens
        //!!!!!!!!!!!!!!!!!! Imagens !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaErrosImagens")]
        public async Task<IActionResult> GetConsultaErrosImagens(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaErrosImagens(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Precos e Custos
        //!!!!!!!!!!!!!!!!!!!  Preços e Custos !!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecosVendas")]
        public async Task<IActionResult> GetConsultaPrecosVendas(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecosVendas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoProduto")]
        public async Task<IActionResult> ConsultaPrecoProduto(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoProduto(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoMoeda")]
        public async Task<IActionResult> GetConsultaPrecoMoeda(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoMoeda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoListingType")]
        public async Task<IActionResult> ConsultaPrecoListingType(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoListingType(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoPorCategoria")]
        public async Task<IActionResult> GetConsultaPrecoPorCategoria(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoPorCategoria(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoMoeda")]
        public async Task<IActionResult> ConsultaPrecoMoeda(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoMoeda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPrecosCustos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTipoPublicacaoCategoria")]
        public async Task<IActionResult> ConsultaTipoPublicacaoCategoria(DadosPrecosCustos dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTipoPublicacaoCategoria(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Identificadores Produtos
        //!!!!!!!!!!!!!!!!!!!!!! Identificadores Produtos !!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaGTIN")]
        public async Task<IActionResult> ConsultaGTIN(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaGTIN(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Variacao
        //!!!!!!!!!!!!!!!!!!!! Variação !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosVariacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutosVariacao")]
        public async Task<IActionResult> ConsultaProdutosVariacao(DadosVariacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutosVariacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosVariacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVariacoes")]
        public async Task<IActionResult> ConsultaVariacoes(DadosVariacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVariacoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosVariacao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVariacaoID")]
        public async Task<IActionResult> ConsultaVariacaoID(DadosVariacao dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVariacaoID(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Tabela de medidas

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Tabela de medidas !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [ProducesResponseType(typeof(DadosTabelaMedidas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDominiosDisponiveisMedidas")]
        public async Task<IActionResult> ConsultaDominiosDisponiveisMedidas(DadosTabelaMedidas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDominiosDisponiveisMedidas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosTabelaMedidas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFichaTecnicaDominio")]
        public async Task<IActionResult> ConsultaFichaTecnicaDominio(DadosTabelaMedidas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFichaTecnicaDominio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosTabelaMedidas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTabelaMedidas")]
        public async Task<IActionResult> ConsultaTabelaMedidas(DadosTabelaMedidas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTabelaMedidasdados(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosTabelaMedidas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPublicacaoStatusCetificado")]
        public async Task<IActionResult> ConsultaPublicacaoStatusCetificado(DadosTabelaMedidas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPublicacaoStatusCetificado(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosTabelaMedidas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaImagemItem")]
        public async Task<IActionResult> ConsultaImagemItem(DadosTabelaMedidas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaImagemItem(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Sincronização e Modificação de Publicações
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaModoEnvioPais")]
        public async Task<IActionResult> ConsultaTempoDisponibilidadeEstoque(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTempoDisponibilidadeEstoque(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaModoEnvioPais")]
        public async Task<IActionResult> ConsultaQuantidadeMaximaCompra(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaQuantidadeMaximaCompra(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Modos de Envio
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Modos Envio Mercadoria !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaModoEnvioPais")]
        public async Task<IActionResult> ConsultaModoEnvioPais(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaModoEnvioPais(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaModosHabilitados")]
        public async Task<IActionResult> ConsultaModosHabilitados(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaModosHabilitados(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPreferenciasEnvioUsuario")]
        public async Task<IActionResult> ConsultaPreferenciasEnvioUsuario(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPreferenciasEnvioUsuario(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPedidosME1")]
        public async Task<IActionResult> ConsultaPedidosME1(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPedidosME1(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaRemessaPedido")]
        public async Task<IActionResult> ConsultaRemessaPedido(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaRemessaPedido(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCategoriaMercadoEnvios")]
        public async Task<IActionResult> ConsultaCategoriaMercadoEnvios(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCategoriaMercadoEnvios(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEtiquetasPDF")]
        public async Task<IActionResult> ConsultaEtiquetasPDF(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEtiquetasPDF(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEtiquetasZPL")]
        public async Task<IActionResult> ConsultaEtiquetasZPL(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEtiquetasZPL(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPedidoID")]
        public async Task<IActionResult> ConsultaPedidoID(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPedidoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOpcoesPedido")]
        public async Task<IActionResult> ConsultaOpcoesPedido(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOpcoesPedido(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPreçoFreteCEP")]
        public async Task<IActionResult> ConsultaPreçoFreteCEP(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPreçoFreteCEP(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPrecoFreteIDCidade")]
        public async Task<IActionResult> ConsultaPrecoFreteIDCidade(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPrecoFreteIDCidade(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTempoEntrega")]
        public async Task<IActionResult> ConsultaTempoEntrega(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTempoEntrega(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCapacidadeVenda")]
        public async Task<IActionResult> ConsultaCapacidadeVenda(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCapacidadeVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTempoMinimoPedido")]
        public async Task<IActionResult> ConsultaTempoMinimoPedido(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTempoMinimoPedido(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaHorariosDespacho")]
        public async Task<IActionResult> ConsultaHorariosDespacho(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaHorariosDespacho(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPontosFacultativos")]
        public async Task<IActionResult> ConsultaPontosFacultativos(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPontosFacultativos(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOpcoesEnvio")]
        public async Task<IActionResult> ConsultaOpcoesEnvio(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOpcoesEnvio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPontosFacultativosData")]
        public async Task<IActionResult> ConsultaPontosFacultativosData(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPontosFacultativosData(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPontosFacultativosVendedor")]
        public async Task<IActionResult> ConsultaPontosFacultativosVendedor(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPontosFacultativosVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutosFreteGratis")]
        public async Task<IActionResult> ConsultaProdutosFreteGratis(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutosFreteGratis(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFlexItem")]
        public async Task<IActionResult> ConsultaFlexItem(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFlexItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCodigoIntegradador")]
        public async Task<IActionResult> ConsultaCodigoIntegradador(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCodigoIntegradador(dados);

            return Content(htmlBoleto);
        }
#endregion
        #region Catalogo
        //!!!!!!!!!!!!!!!!  Catálogo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCatalogoItensVendedor")]
        public async Task<IActionResult> ConsultaCatalogoItensVendedor(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCatalogoItensVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensVendedorSemCatalogo")]
        public async Task<IActionResult> ConsultaItensVendedorSemCatalogo(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensVendedorSemCatalogo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCatalogoItensVendedorElegibilidade")]
        public async Task<IActionResult> ConsultaCatalogoItensVendedorElegibilidade(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCatalogoItensVendedorElegibilidade(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCatalogoListaElegibilidade")]
        public async Task<IActionResult> ConsultaCatalogoListaElegibilidade(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCatalogoListaElegibilidade(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMultiplasPublicacoes")]
        public async Task<IActionResult> ConsultaMultiplasPublicacoes(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMultiplasPublicacoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesProdutoDescricao")]
        public async Task<IActionResult> ConsultaDetalhesProdutoDescricao(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesProdutoDescricao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesProdutoDominio")]
        public async Task<IActionResult> ConsultaDetalhesProdutoDominio(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesProdutoDominio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesProdutoID")]
        public async Task<IActionResult> ConsultaDetalhesProdutoID(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesProdutoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutoParaPublicar")]
        public async Task<IActionResult> ConsultaProdutoParaPublicar(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutoParaPublicar(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutoCriacaoAutomaticaItens")]
        public async Task<IActionResult> ConsultaProdutoCriacaoAutomaticaItens(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutoCriacaoAutomaticaItens(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaIdentificarProdutosPreviamente")]
        public async Task<IActionResult> ConsultaIdentificarProdutosPreviamente(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutoPreviamente(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCatalogoItensAvisoPrevio")]
        public async Task<IActionResult> ConsultaCatalogoItensAvisoPrevio(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCatalogoItensAvisoPrevio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCatalogoItensAvisoPrevioData")]
        public async Task<IActionResult> ConsultaCatalogoItensAvisoPrevioData(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCatalogoItensAvisoPrevioData(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaInfracoes")]
        public async Task<IActionResult> ConsultaInfracoes(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaInfracoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesPublicacaoConcorencia")]
        public async Task<IActionResult> ConsultaDetalhesPublicacaoConcorencia(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesPublicacaoConcorencia(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPublicacoesPDP")]
        public async Task<IActionResult> ConsultaPublicacoesPDP(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPublicacoesPDP(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPublicacoesPDPFiltros")]
        public async Task<IActionResult> ConsultaPublicacoesPDPFiltros(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPublicacoesPDPFiltros(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaSugestoesUsuario")]
        public async Task<IActionResult> ConsultaSugestoesUsuario(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultSugestoesUsuario(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDominiodDisponiveis")]
        public async Task<IActionResult> ConsultaDominiodDisponiveis(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDominiodDisponiveis(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFichaTecnicaDominioCatalogo")]
        public async Task<IActionResult> ConsultaFichaTecnicaDominioCatalogo(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFichaTecnicaDominioCatalogo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFichaTecnicaSugestoes")]
        public async Task<IActionResult> ConsultaFichaTecnicaSugestoes(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFichaTecnicaSugestoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaSugestaoID")]
        public async Task<IActionResult> ConsultaSugestaoID(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaSugestaoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaResultadoValidacoes")]
        public async Task<IActionResult> ConsultaResultadoValidacoes(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaResultadoValidacoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosCatalogo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaSugestoes")]
        public async Task<IActionResult> ConsultaSugestoes(DadosCatalogo dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaSugestoes(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Estoque Fulfillment
        //!!!!!!!!!!!!!!!!!!!!!!! Estoque Fulfillment !!!!!!!!!!!
        [ProducesResponseType(typeof(DadosEstoqueFulfillment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEstoqueFulfillment")]
        public async Task<IActionResult> ConsultaEstoqueFulfillment(DadosEstoqueFulfillment dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEstoqueFulfillment(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEstoqueFulfillment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesEstoqueNaoDisponvel")]
        public async Task<IActionResult> ConsultaDetalhesEstoqueNaoDisponvel(DadosEstoqueFulfillment dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesEstoqueNaoDisponvel(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEstoqueFulfillment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ReceberNotificacoesEstoque")]
        public async Task<IActionResult> ReceberNotificacoesEstoque(DadosEstoqueFulfillment dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaReceberNotificacoesEstoque(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEstoqueFulfillment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOperacoesID")]
        public async Task<IActionResult> ConsultaOperacoesID(DadosEstoqueFulfillment dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOperacoesID(dados);

            return Content(htmlBoleto);
        }

        #endregion
        #region Gerencie Promoções
        //!!!!!!!!!!!!!!!!!!!!!!! Gerencie Promoções !!!!!!!!!!!
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPromocoesVendedor")]
        public async Task<IActionResult> ConsultaPromocoesVendedor(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPromocoesVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCandidatos")]
        public async Task<IActionResult> ConsultaItensCandidatos(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCandidatos(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItemCandidatoID")]
        public async Task<IActionResult> ConsultaItemCandidatoID(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItemCandidatoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOfertas")]
        public async Task<IActionResult> ConsultaOfertas(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOfertas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesPromocao")]
        public async Task<IActionResult> ConsultaDetalhesPromocao(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesPromocao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensPromocao")]
        public async Task<IActionResult> ConsultaItensPromocao(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensPromocao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensPromocaoFiltro")]
        public async Task<IActionResult> ConsultaItensPromocaoFiltro(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensPromocaoFiltro(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensPromocaoPaginacao")]
        public async Task<IActionResult> ConsultaItensPromocaoPaginacao(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensPromocaoPaginacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPromocaoItens")]
        public async Task<IActionResult> ConsultaPromocaoItens(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPromocaoItens(dados);

            return Content(htmlBoleto);
        }
        #region Campanhas Normal
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanha")]
        public async Task<IActionResult> ConsultaDetalhesCampanha(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCampanha(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanha")]
        public async Task<IActionResult> ConsultaItensCampanha(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanha(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Campanhas Co-participação
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanhaCoparticipacao")]
        public async Task<IActionResult> ConsultaDetalhesCampanhaCoparticipacao(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCampanhaCoparticipacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaCoparticipacao")]
        public async Task<IActionResult> ConsultaItensCampanhaCoparticipacao(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaCoparticipacao(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Campanhas de Desconto por Volume
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanhaDescontoVolume")]
        public async Task<IActionResult> ConsultaDetalhesCampanhaDescontoVolume(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCampanhaDescontoVolume(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaDescontoVolume")]
        public async Task<IActionResult> ConsultaItensCampanhaDescontoVolume(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaDescontoVolume(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Desconto Pré-Acordado por Item
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanhaPreAcordo")]
        public async Task<IActionResult> ConsultaDetalhesCampanhaPreAcordo(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCampanhaPreAcordo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaPreAcordo")]
        public async Task<IActionResult> ConsultaItensCampanhaPreAcordo(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarItensCampanhaPreAcordo(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Ofertas do Dia
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaOfertaDia")]
        public async Task<IActionResult> ConsultaItensCampanhaOfertaDia(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaOfertaDia(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Ofertas Relâmpago
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaOfertaRelampago")]
        public async Task<IActionResult> ConsultaItensCampanhaOfertaRelampago(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaOfertaRelampago(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Campanhas do Vendedor
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanhaVendedor")]
        public async Task<IActionResult> ConsultaDetalhesCampanhaVendedor(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCampanhaVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaVendedor")]
        public async Task<IActionResult> ConsultaItensCampanhaVendedor(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaVendedor(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Campanhas Smart
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCampanhaSmart")]
        public async Task<IActionResult> ConsultaDetalhesCampanhaSmart(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarDetalhesCampanhaSmart(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPromocoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensCampanhaSmart")]
        public async Task<IActionResult> ConsultaItensCampanhaSmart(DadosPromocoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensCampanhaSmart(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #endregion
        #region Perguntas e Respostas
        //!!!!!!!!!!!!!!!!!!!!!! Perguntas e  Respostas !!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasRecebidasVendedor")]
        public async Task<IActionResult> ConsultaPerguntasRecebidasVendedor(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarPerguntasRecebidasVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasRecebidasProduto")]
        public async Task<IActionResult> ConsultaPerguntasRecebidasProduto(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPerguntasRecebidasProduto(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasRecebidasProdutoSortFields")]
        public async Task<IActionResult> ConsultaPerguntasRecebidasProdutoSortFields(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarPerguntasRecebidasProdutoSortFields(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasRecebidasProdutoSortTypes")]
        public async Task<IActionResult> ConsultaPerguntasRecebidasProdutoSortTypes(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPerguntasRecebidasProdutoSortTypes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasFeitasUsuarioProduto")]
        public async Task<IActionResult> ConsultaPerguntasFeitasUsuarioProduto(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPerguntasFeitasUsuarioProduto(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPerguntasId")]
        public async Task<IActionResult> ConsultaPerguntasId(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPerguntasId(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCalculaTempoResposta")]
        public async Task<IActionResult> ConsultaCalculaTempoResposta(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCalculaTempoResposta(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosPerguntasRespostas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaUsuariosBloqueados")]
        public async Task<IActionResult> ConsultaUsuariosBloqueados(DadosPerguntasRespostas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaUsuariosBloqueados(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Gerencie Vendas
        //!!!!!!!!!!!!!!!!!!!! Gerencie Vendas !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNovaVenda")]
        public async Task<IActionResult> ConsultaNovaVenda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNovaVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaConversaoMoeda")]
        public async Task<IActionResult> ConsultaConversaoMoeda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaConversaoMoeda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProdutosMesmaVenda")]
        public async Task<IActionResult> ConsultaProdutosMesmaVenda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProdutosMesmaVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("ConsultaVendas")]
        public async Task<IActionResult> ConsultaVendas(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("ConsultaVendasFiltros")]
        public async Task<IActionResult> ConsultaVendasFiltros(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosConsultar = new MetodosConsultar(dados.logar);
            var content = metodosConsultar.RetornarConsultaVendasFiltros(dados);

            return Content(content);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasOrdenacao")]
        public async Task<IActionResult> ConsultaVendasOrdenacao(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasOrdenacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasRecentes")]
        public async Task<IActionResult> ConsultaVendasRecentes(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasRecentes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasPendentes")]
        public async Task<IActionResult> ConsultaVendasPendentes(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasPendentes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasArquivadas")]
        public async Task<IActionResult> ConsultaVendasArquivadas(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasArquivadas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasArquivadasComprador")]
        public async Task<IActionResult> ConsultaVendasArquivadasComprador(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasArquivadasComprador(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendaOpcoes")]
        public async Task<IActionResult> ConsultaVendaOpcoes(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendaOpcoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVendasCarrinho")]
        public async Task<IActionResult> ConsultaVendasCarrinho(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVendasCarrinho(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("ConsultaEnvios")]
        public async Task<IActionResult> ConsultaEnvios(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEnvios(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensEnvio")]
        public async Task<IActionResult> ConsultaItensEnvio(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensEnvio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaCustosEnvio")]
        public async Task<IActionResult> ConsultaCustosEnvio(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaCustosEnvio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPagamentosEnvio")]
        public async Task<IActionResult> ConsultaPagamentosEnvio(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPagamentosEnvio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaProzoEntrega")]
        public async Task<IActionResult> ConsultaProzoEntrega(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaProzoEntrega(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEnviosAtrasados")]
        public async Task<IActionResult> ConsultaEnviosAtrasados(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEnviosAtrasados(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaHistoricoPedido")]
        public async Task<IActionResult> ConsultaHistoricoPedido(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaHistoricoPedido(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaUrlRastreio")]
        public async Task<IActionResult> ConsultaUrlRastreio(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaUrlRastreio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaStatusSubstaus")]
        public async Task<IActionResult> ConsultaStatusSubstaus(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaStatusSubstaus(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFeedbackVenda")]
        public async Task<IActionResult> ConsultaFeedbackVenda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFeedbackVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFeedBackIDVenda")]
        public async Task<IActionResult> ConsultaFeedBackIDVenda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFeedBackIDVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotasVenda")]
        public async Task<IActionResult> ConsultaNotasVenda(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotasVenda(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosGerencieVendas), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaUsuariosBloqueadosVendas")]
        public async Task<IActionResult> ConsultaUsuariosBloqueadosVendas(DadosGerencieVendas dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaUsuariosBloqueadosVendas(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Faturador Mercado Livre
        //!!!!!!!!!!!!!!!!!!!!!! Faturador Mercado Livre !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaItensVendedor")]
        public async Task<IActionResult> ConsultaItensVendedor(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaItensVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaErrosEmissaoNota")]
        public async Task<IActionResult> ConsultaErrosEmissaoNota(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaErrosEmissaoNota(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaRegrasTributrias")]
        public async Task<IActionResult> ConsultaRegrasTributrias(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaRegrasTributrias(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaRegraTributariaID")]
        public async Task<IActionResult> ConsultaRegraTributariaID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaRegraTributariaID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("onsultaMensagensTributacao")]
        public async Task<IActionResult> onsultaMensagensTributacao(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensTributacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensTributacaoID")]
        public async Task<IActionResult> ConsultaMensagensTributacaoID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensTributacaoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDadosFiscaisSKU")]
        public async Task<IActionResult> ConsultaDadosFiscaisSKU(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDadosFiscaisSKU(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDadosFiscaisItem")]
        public async Task<IActionResult> ConsultaDadosFiscaisItem(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDadosFiscaisItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPublicacaoPodeSerFaturada")]
        public async Task<IActionResult> ConsultaPublicacaoPodeSerFaturada(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPublicacaoPodeSerFaturada(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVariacaoID")]
        public async Task<IActionResult> ConsultaVariacaoID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVariacaoID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaInscricaoEstadualCNPJ")]
        public async Task<IActionResult> ConsultaInscricaoEstadualCNPJ(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaInscricaoEstadualCNPJ(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaInscricaoEstadualCNPJEstado")]
        public async Task<IActionResult> ConsultaInscricaoEstadualCNPJEstado(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaInscricaoEstadualCNPJEstado(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaXMLNota")]
        public async Task<IActionResult> ConsultaXMLNota(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaXMLNota(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaStatusNotaInvoiceID")]
        public async Task<IActionResult> ConsultaStatusNotaInvoiceID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaStatusNotaInvoiceID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaStatusNotaOrderID")]
        public async Task<IActionResult> ConsultaStatusNotaOrderID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaStatusNotaOrderID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaStatusRemessaInvoiceID")]
        public async Task<IActionResult> ConsultaStatusRemessaInvoiceID(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaStatusRemessaInvoiceID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotasMes")]
        public async Task<IActionResult> ConsultaNotasMes(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotasMes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotasPeriodo")]
        public async Task<IActionResult> ConsultaNotasPeriodo(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotasPeriodo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotasFiltrosCTE")]
        public async Task<IActionResult> ConsultaNotasFiltrosCTE(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotasFiltrosCTE(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosFaturador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensCadastrada")]
        public async Task<IActionResult> ConsultaMensagensCadastrada(DadosFaturador dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensCadastrada(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Relatório Faturamento
        //!!!!!!!!!!!!!!!!!!!!! Relatório Faturamento !!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaFaturamentoPeriodo")]
        public async Task<IActionResult> ConsultaFaturamentoPeriodo(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaFaturamentoPeriodo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaResumoFaturamento")]
        public async Task<IActionResult> ConsultaResumoFaturamento(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaResumoFaturamento(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesConciliacao")]
        public async Task<IActionResult> ConsultaDetalhesConciliacao(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesConciliacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCobrancaMercadoPago")]
        public async Task<IActionResult> ConsultaDetalhesCobrancaMercadoPago(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCobrancaMercadoPago(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCobrancaMercadoEnvioFlex")]
        public async Task<IActionResult> ConsultaDetalhesCobrancaMercadoEnvioFlex(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCobrancaMercadoEnvioFlex(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesCobrancaFulfillment")]
        public async Task<IActionResult> ConsultaDetalhesCobrancaFulfillment(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesCobrancaFulfillment(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesEncargosBonificacaoGarantia")]
        public async Task<IActionResult> ConsultaDetalhesEncargosBonificacaoGarantia(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesEncargosBonificacaoGarantia(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("DownloadDocumentoLegal")]
        public async Task<IActionResult> DownloadDocumentoLegal(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarDownloadDocumentoLegal(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEstadoCriacaoRelatorio")]
        public async Task<IActionResult> ConsultaEstadoCriacaoRelatorio(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEstadoCriacaoRelatorio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("DownLoadRelatorio")]
        public async Task<IActionResult> DownLoadRelatorio(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarDownLoadRelatorio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaResumoPercepcoes")]
        public async Task<IActionResult> ConsultaResumoPercepcoes(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaResumoPercepcoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesPercepcao")]
        public async Task<IActionResult> ConsultaDetalhesPercepcao(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesPercepcao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosRelatorioFaturamento), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesPercepcaoMercadoPagado")]
        public async Task<IActionResult> ConsultaDetalhesPercepcaoMercadoPagado(DadosRelatorioFaturamento dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesPercepcaoMercadoPagado(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Enviar Nota Fiscal
        //!!!!!!!!!!!!!!!!!!!!! Enviar Nota Fiscal !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDadosFaturamento")]
        public async Task<IActionResult> ConsultaDadosFaturamento(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDadosFaturamento(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("ConsultaBillingInfo")]
        public async Task<IActionResult> ConsultaBillingInfo(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaBillingInfo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNotaFiscalEnviada")]
        public async Task<IActionResult> ConsultaNotaFiscalEnviada(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNotaFiscalEnviada(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaIDsNF")]
        public async Task<IActionResult> ConsultaIDsNF(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaIDsNF(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaNF")]
        public async Task<IActionResult> ConsultaNF(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaNF(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosEnviarNotaFiscal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("EnviarXmlNotaFiscal")]
        public async Task<IActionResult> EnviarXmlNotaFiscal(DadosEnviarNotaFiscal dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosConsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosConsultar.RetornarConsultaNF(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Mensagens Pós Venda
        //!!!!!!!!!!!!!!!!!!!!!!!!!!! Mensagens Pós Venda !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOpcoesComunicacaoDisponiveis")]
        public async Task<IActionResult> ConsultaOpcoesComunicacaoDisponiveis(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOpcoesComunicacaoDisponiveis(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaQtdDisponivelMensagens")]
        public async Task<IActionResult> ConsultaQtdDisponivelMensagens(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaQtdDisponivelMensagens(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensPacote")]
        public async Task<IActionResult> ConsultaMensagensPacote(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensPacote(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensID")]
        public async Task<IActionResult> ConsultaMensagensID(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensID(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAnexosMensagem")]
        public async Task<IActionResult> ConsultaAnexosMensagem(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAnexosMensagem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensPendentes")]
        public async Task<IActionResult> ConsultaMensagensPendentes(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensPendentes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensPendentesVendedor")]
        public async Task<IActionResult> ConsultaMensagensPendentesVendedor(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensPendentesVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("MarcarMensagensLidas")]
        public async Task<IActionResult> MarcarMensagensLidas(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensLidas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensNaoLidas")]
        public async Task<IActionResult> ConsultaMensagensNaoLidas(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensNaoLidas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosMensagensPosVenda), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensBloqueadas")]
        public async Task<IActionResult> ConsultaMensagensBloqueadas(DadosMensagensPosVenda dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensBloqueadas(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Métricas e Tendências 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Métricas e Tendências !!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOpinioesProduto")]
        public async Task<IActionResult> ConsultaOpinioesProduto(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOpinioesProduto(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaOpnioesCatalogoProdutos")]
        public async Task<IActionResult> ConsultaOpnioesCatalogoProdutos(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaOpnioesCatalogoProdutos(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaReputacaoVendedores")]
        public async Task<IActionResult> ConsultaReputacaoVendedores(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaReputacaoVendedores(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTendenciasPais")]
        public async Task<IActionResult> ConsultaTendenciasPais(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTendenciasPais(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaTendenciasPaisCategoria")]
        public async Task<IActionResult> ConsultaTendenciasPaisCategoria(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaTendenciasPaisCategoria(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaQualidadePublicacoesPais")]
        public async Task<IActionResult> ConsultaQualidadePublicacoesPais(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaQualidadePublicacoesPais(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesQualidadeItem")]
        public async Task<IActionResult> ConsultaDetalhesQualidadeItem(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesQualidadeItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaAcoesQualidadeItem")]
        public async Task<IActionResult> ConsultaAcoesQualidadeItem(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaAcoesQualidadeItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMaisVendidosCategoria")]
        public async Task<IActionResult> ConsultaMaisVendidosCategoria(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMaisVendidosCategoria(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMaisVendidosCategoriaMarca")]
        public async Task<IActionResult> ConsultaMaisVendidosCategoriaMarca(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMaisVendidosCategoriaMarca(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPosicionamentoProduto")]
        public async Task<IActionResult> ConsultaPosicionamentoProduto(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPosicionamentoProduto(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaPosicionamentoItem")]
        public async Task<IActionResult> ConsultaPosicionamentoItem(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaPosicionamentoItem(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVisitasUsuario")]
        public async Task<IActionResult> ConsultaVisitasUsuario(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVisitasUsuario(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVisitasAnuncio")]
        public async Task<IActionResult> ConsultaVisitasAnuncio(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVisitasAnuncio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVisitasAnuncioData")]
        public async Task<IActionResult> ConsultaVisitasAnuncioData(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVisitasAnuncioData(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVisitasAnuncioDataUsuario")]
        public async Task<IActionResult> ConsultaVisitasAnuncioDataUsuario(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVisitasAnuncioDataUsuario(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaVisitasDataAnuncio")]
        public async Task<IActionResult> ConsultaVisitasDataAnuncio(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaVisitasDataAnuncio(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaStatusVendedor")]
        public async Task<IActionResult> ConsultaStatusVendedor(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaStatusVendedor(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(MetricasTendencias), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaQualidadeAnuncio")]
        public async Task<IActionResult> ConsultaQualidadeAnuncio(MetricasTendencias dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaQualidadeAnuncio(dados);

            return Content(htmlBoleto);
        }
        #endregion
        # region Reclamações Devoluções
        //!!!!!!!!!!!!!!!!!! Reclamações Devoluções !!!!!!!!!!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaReclamacoes")]
        public async Task<IActionResult> ConsultaReclamacoes(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaReclamacoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaReclamacoesFiltros")]
        public async Task<IActionResult> ConsultaReclamacoesFiltros(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaReclamacoesFiltros(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaReclamacoesOrdenecacao")]
        public async Task<IActionResult> ConsultaReclamacoesOrdenecacao(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaReclamacoesOrdenecacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDetalhesReclamacao")]
        public async Task<IActionResult> ConsultaDetalhesReclamacao(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDetalhesReclamacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMensagensREclamacao")]
        public async Task<IActionResult> ConsultaMensagensREclamacao(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMensagensREclamacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaArquivosReclamacoes")]
        public async Task<IActionResult> ConsultaArquivosReclamacoes(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaArquivosReclamacoes(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaInformacoesArquivo")]
        public async Task<IActionResult> ConsultaInformacoesArquivo(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaInformacoesArquivo(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaResolucaoEsperadas")]
        public async Task<IActionResult> ConsultaResolucaoEsperadas(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaResolucaoEsperadas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaEvidenciasReclamacao")]
        public async Task<IActionResult> ConsultaEvidenciasReclamacao(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaEvidenciasReclamacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaHistoricoAcoesReclamacao")]
        public async Task<IActionResult> ConsultaHistoricoAcoesReclamacao(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaHistoricoAcoesReclamacao(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosReclamacoesDevolucoes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaDevolucoes")]
        public async Task<IActionResult> ConsultaDevolucoes(DadosReclamacoesDevolucoes dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaDevolucoes(dados);

            return Content(htmlBoleto);
        }
        #endregion
        #region Mercado Lider Lojas Oficiais
        //!!!!!!!!!!!!!!!!!! Mercado Lider Lojas Oficiais !!!!!!!!!!!!!!!!!
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMarcas")]
        public async Task<IActionResult> ConsultaMarcas(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMarcas(dados);

            return Content(htmlBoleto);
        }
        [ProducesResponseType(typeof(DadosConsulta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("ConsultaMarcasID")]
        public async Task<IActionResult> ConsultaMarcasID(DadosConsulta dados)
        {
            if (dados.logar == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar os dados de login para acessar as APIs do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }
            if (dados == null)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Não há dados para consultas via API do Mercado Livre!", "/api/ConsultasMercadoLivre");
                return BadRequest(retorno);
            }

            MetodosConsultar metodosColsultar = new MetodosConsultar(dados.logar);
            var htmlBoleto = metodosColsultar.RetornarConsultaMarcasID(dados);

            return Content(htmlBoleto);
        }
        #endregion
    }
}

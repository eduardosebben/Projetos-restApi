using BoletoApiCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BoletoApiCore.Extensions;
using BoletoNetCore;
using BoletoNetCore.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace BoletoApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletosController : ControllerBase
    {
        MetodosUteis metodosUteis = new MetodosUteis();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BoletosController> _logger;

        public BoletosController(ILogger<BoletosController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Método usado para teste , ver se API está online
        /// </summary>
        /// <returns></returns>
        //[HttpGet("Ping")]
        [HttpGet("Ping")]
        public  string Ping()
        {
            return "Pong pong";
        }

        [ProducesResponseType(typeof(DadosBoleto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("GerarBoletos")]
        public async Task<IActionResult> PostGerarBoletos(DadosBoleto dadosBoleto, int tipoBancoEmissor, [FromHeader(Name = "token")] string token)
        {
            //comentário para teste!!!!!
            try
            {
                var validaToken = "Ap0a3ljV2rXddVHxKxaIiJ0BFvDIN3d0CUqd7JPzCR5YVGsjPMtWdtzhqo3en5qmtGIZfMIBlDqfZxbDvkYyd0564930185e779d";

                if (validaToken.Equals(token))
                {
                    if (dadosBoleto.BeneficiarioResponse.CPFCNPJ == null || (dadosBoleto.BeneficiarioResponse.CPFCNPJ.Length != 11 && dadosBoleto.BeneficiarioResponse.CPFCNPJ.Length != 14))
                    {
                        var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "CPF/CNPJ inválido: Utilize 11 dígitos para CPF ou 14 para CNPJ.", "/api/Boletos/BoletoItau");
                        return BadRequest(retorno);
                    }

                    if (string.IsNullOrWhiteSpace(dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.CarteiraPadrao))
                    {
                        var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Favor informar a carteira do banco.", "/api/Boletos/BoletoItau");
                        return BadRequest(retorno);
                    }

                    GerarBoletoBancos gerarBoletoBancos = new GerarBoletoBancos(Banco.Instancia(metodosUteis.RetornarBancoEmissor(tipoBancoEmissor)));
                    var htmlBoleto = gerarBoletoBancos.RetornarHtmlBoleto(dadosBoleto);

                    return Content(htmlBoleto, "text/html");

                }
                else
                {
                    var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Favor informar o token!", "/api/Boletos/BoletoItau");
                    return BadRequest(retorno);
                }

                return null;


            }catch(Exception ex)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.InternalServerError, "Requisição Inválida", $"Detalhe do erro: {ex.Message}", string.Empty);
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }

        }
    }
}

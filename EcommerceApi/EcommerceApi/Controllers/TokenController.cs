using BoletoNetCore.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using EcommerceApi.Banco_de_Dados;
using EcommerceApi.Dominio;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        MetodosUteis metodosUteis = new MetodosUteis();
        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials credentials,[FromHeader(Name = "ApiKey")] string ApiKey)
        {
            if (string.IsNullOrEmpty(ApiKey))
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Necessário enviar a API Key!", "api/Token/login");
                return BadRequest(retorno);
            }
            else
            {
                if (ApiKey == Configuration["token"])
                {
                    var stringConexao = Configuration["conectionString"];
                    var cn = SqlConn.Init(stringConexao);
                    var UsuarioValido = DominioEcommerceApi.ConsultaUsuario(credentials, cn);

                    if (UsuarioValido)
                    {
                        var token = GenerateToken(credentials.email);
                        return Ok(new { Token = token });
                    }
                    else
                    {
                        var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Usuário e senha inválidos!", "api/Token/login");
                        return BadRequest(retorno);
                    }
                }
                else
                {
                    var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "Api Key inválida!", "api/Token/login");
                    return BadRequest(retorno);
                }
            }
        }

        private AuthenticationResponse GenerateToken(string email)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var issuer = Configuration["Jwt:Issuer"];
            var audience = Configuration["Jwt:Audience"];
            var expiration = DateTime.UtcNow.AddMinutes(60);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(60), // Tempo de expiração do token (15 minutos neste exemplo).
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenValido = tokenHandler.WriteToken(token);

            var authentication = new AuthenticationResponse();
            authentication.Token = tokenValido;
            authentication.Expiration = expiration;

            return authentication;

        }
    }

    public class UserCredentials
    {
        public string email { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
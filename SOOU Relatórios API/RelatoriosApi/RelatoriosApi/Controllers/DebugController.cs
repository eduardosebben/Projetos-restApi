using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Relatorios.Aplication.Fiscal.Models;
using Relatorios.Aplication.Fiscal.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using Relatorios.Aplication.Common.Implementacoes;
using SoouCommon.Enum;
using SoouCommon.Jwt;

namespace RelatoriosApi.Controllers
{
#if DEBUG
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class DebugController : ControllerBase
    {
        
        private readonly ICriptografiaProvider _criptografiaProvider;

        public DebugController(ICriptografiaProvider criptografiaProvider)
        {
            _criptografiaProvider = criptografiaProvider;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/GenerateToken")]

        public async Task<IActionResult> GenerateToken()
        {
            return Ok(await GerarToken("2c4520af-c6da-460f-9357-5f2ccc8a936b", "", TipoAplicacao.Maboo, TipoAmbiente.Desenvolvimento));
        }

        private async Task<string> GerarToken(string OrgGuid, string UserGuid, TipoAplicacao OriginApp, TipoAmbiente OriginEnv, int NumeroDiasExpiracao = 3, bool TipValidarRelacaoOrganizacao = false)
        {
            var token = new TokenPayloadData()
            {
                OrgGuid = OrgGuid,
                UserGuid = UserGuid,
                OriginApp = OriginApp,
                OriginEnv = OriginEnv,
                TipValidarRelacaoOrganizacao = TipValidarRelacaoOrganizacao
            };

            var tokenJson = JsonSerializer.Serialize(token);
            var dados = _criptografiaProvider.CriptografarUTF8(tokenJson);

            ClaimsIdentity claims = new ClaimsIdentity(
                new[]
                {
                    new Claim("appdata", dados)
                });

            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0x4Dnul6QzspkpJ+/gesmSgvL53lyZuZbdSXe85I/f2osWtkxzIaUFuPHcAiOH55/E6w2Cry2d5GTK7KjeiPztmIg+bRZi7Anjd8zZPXZy07YJ"));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "ConectaAccount",
                Audience = "Any",
                SigningCredentials = sc,
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(NumeroDiasExpiracao),
                IssuedAt = DateTime.UtcNow
            });

            return handler.WriteToken(securityToken);
            
        }

    }
#endif
}
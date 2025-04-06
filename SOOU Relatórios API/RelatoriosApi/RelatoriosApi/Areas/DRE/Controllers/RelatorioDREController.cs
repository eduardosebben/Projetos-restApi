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
using RelatoriosApi.Controllers;
using RelatoriosApi.Models;
using Relatorios.Aplication.DRE.Services;
using Relatorios.Aplication.DRE.Models;

namespace RelatoriosApi.Areas.DRE.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[area]/[controller]")]
    [Area("DRE")]
    public class RelatorioDREController : ControllerBase
    {
        private readonly IServicoRelatorioDRE _relatorioDREService;

        public RelatorioDREController(IServicoRelatorioDRE relatorioDREService)
        {
            _relatorioDREService = relatorioDREService;
        }

        [HttpPost("RelatorioDRE")]
        public async Task<IActionResult> RelatorioDRE(ConfiguradorRelatorioDREDto filtro)
        {
            var result = await _relatorioDREService.RetornarRelatorioDRE(filtro);
            return Ok(new ApiResponse<RetornoDRE>(result));
        }

        [HttpPost("RelatorioDREContaMercadoriaVendida")]
        public async Task<IActionResult> RelatorioDREContaMercadoriaVendida(ConfiguradorRelatorioDREDto filtro)
        {
            var result = await _relatorioDREService.RetornarValorContaMercadoriaVendida(filtro);
            return Ok(new ApiResponse<RetornoDRE>(result));
        }
    }
}
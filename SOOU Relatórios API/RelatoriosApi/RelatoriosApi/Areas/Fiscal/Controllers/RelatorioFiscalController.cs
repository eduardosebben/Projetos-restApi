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
using Relatorios.Aplication.Fiscal.Models.ApuracaoIcms;

namespace RelatoriosApi.Areas.Fiscal.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[area]/[controller]")]
    [Area("Fiscal")]
    public class RelatorioFiscalController : ApiPadraoController
    {
        private readonly IRelatorioLivroFiscalService _relatorioLivroFiscalService;

        public RelatorioFiscalController(IRelatorioLivroFiscalService relatorioLivroFiscalService)
        {
            _relatorioLivroFiscalService = relatorioLivroFiscalService;
        }

        [HttpPost("RelatorioLivroSaida")]
        public async Task<IActionResult> RelatorioLivroSaida(RelatorioLivroSaidaRequest request)
        {
            var result = await _relatorioLivroFiscalService.RelatorioLivroSaida(request);
            return OkPadrao(result);
        }

        [HttpPost("RelatorioLivroEntrada")]
        public async Task<IActionResult> RelatorioLivroEntrada(RelatorioLivroEntradaRequest request)
        {
            var result = await _relatorioLivroFiscalService.RelatorioLivroEntrada(request);
            return OkPadrao(result);
        }

        [HttpPost("RelatorioApuracaoIcms")]
        public async Task<IActionResult> RelatorioApuracaoIcms(RelatorioApuracaoIcmsRequest request)
        {
            var result = await _relatorioLivroFiscalService.RelatorioApuracaoIcms(request);
            return OkPadrao(result);
        }
    }
}
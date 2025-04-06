using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Relatorios.Aplication.DRE.Models;
using Relatorios.Aplication.FaturamentoContratos.Services;
using RelatoriosApi.Models;
using Relatorios.Aplication.FaturamentoContratos.Models;
using RelatoriosApi.Controllers;

namespace RelatoriosApi.Areas.Contratos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[area]/[controller]")]
    [Area("Contratos")]
    public class FaturamentoController : ApiPadraoController
    {
        private readonly IGerarFaturamentoContratoService _gerarFaturamentoContratoService;
        public FaturamentoController(IGerarFaturamentoContratoService gerarFaturamentoContratoService)
        {
            _gerarFaturamentoContratoService = gerarFaturamentoContratoService;
        }

        [HttpPost("ConsultarFaturamento")]
        public async Task<IActionResult> ConsultarFaturamento(ConsultaGeracaoFaturamentoRequest request)
        {
            var result = await _gerarFaturamentoContratoService.ConsultarFaturamento(request);
            return OkPadrao(result);
        }

    }
}

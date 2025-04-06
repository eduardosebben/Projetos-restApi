using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relatorios.Aplication.EvolucaoCompras.Models;
using Relatorios.Aplication.EvolucaoCompras.Services;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Aplication.Inventario.Services;
using RelatoriosApi.Controllers;

namespace RelatoriosApi.Areas.Inventario.Controllers
{
    [Area("Suprimentos")]
    public class EvolucaoCompraController : ApiPadraoController
    {
        
        private readonly IEvolucaoCompraService _evolucaoCompraService;

        public EvolucaoCompraController(IEvolucaoCompraService evolucaoCompraService)
        {
            _evolucaoCompraService = evolucaoCompraService;
        }

        [HttpPost("GetRelatorioEvolucaoCompras")]
        public async Task<IActionResult> GetRelatorioEvolucaoCompras(EvolucaoCompraRequest request)
        {
            var result = await _evolucaoCompraService.EvolucaoCompra(request);
            return OkPadrao(result);
        }

    }



}

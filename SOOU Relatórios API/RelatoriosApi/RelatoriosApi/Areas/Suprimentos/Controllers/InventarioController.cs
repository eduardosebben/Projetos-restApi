using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Aplication.Inventario.Services;
using RelatoriosApi.Controllers;

namespace RelatoriosApi.Areas.Inventario.Controllers
{
    [Area("Suprimentos")]
    public class InventarioController : ApiPadraoController
    {
        private readonly IServicoRelatorioInventario _servicoRelatorioInventario;

        public InventarioController(IServicoRelatorioInventario servicoRelatorioInventario)
        {
            _servicoRelatorioInventario = servicoRelatorioInventario;
        }

        [HttpPost("RelatorioInventario")]
        public async Task<IActionResult> GetRelatorioInventario(ConfiguradorRelatorioInventarioDto filtro)
        {
            var result = await _servicoRelatorioInventario.RetornarRelatorioInventario(filtro);
            return OkPadrao(result);
        }

    }


    
}

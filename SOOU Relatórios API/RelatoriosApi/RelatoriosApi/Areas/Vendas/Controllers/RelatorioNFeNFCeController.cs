using Microsoft.AspNetCore.Mvc;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Aplication.Vendas.Models;
using Relatorios.Aplication.Vendas.Services;
using RelatoriosApi.Controllers;

namespace RelatoriosApi.Areas.Vendas.Controllers
{
    [Area("Vendas")]
    public class RelatorioNFeNFCeController : ApiPadraoController
    {
        private IServicoRelatorioNFeNFCe _servicoRelatorioNFeNFCe;

        public RelatorioNFeNFCeController(IServicoRelatorioNFeNFCe servicoRelatorioNFeNFCe)
        {
            _servicoRelatorioNFeNFCe = servicoRelatorioNFeNFCe;
        }

        [HttpPost("RelatorioNFeNFCeNFSe")]
        public async Task<IActionResult> RelatorioNFeNFCeNFSe(FiltroRelatorioNFe filtros)
        {
            var result = await _servicoRelatorioNFeNFCe.RelatorioNFeNFCe(filtros);
            return OkPadrao(result);
        }
    }
}

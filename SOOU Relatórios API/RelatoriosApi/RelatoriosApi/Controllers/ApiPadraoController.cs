using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Fiscal.Models;
using RelatoriosApi.Models;


namespace RelatoriosApi.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Authorize]
    public class ApiPadraoController : ControllerBase
    {

        public IActionResult OkPadrao<T>(T result)
        {
            return Ok(new ApiResponse<T>(result));
        }

        public IActionResult OkPadrao<TValue, TError>(Result<TValue, TError> result)
        {
            if(!result.IsSucess)
                return BadRequest(result.Error);

            return OkPadrao(result.Value);
        }
    }
}

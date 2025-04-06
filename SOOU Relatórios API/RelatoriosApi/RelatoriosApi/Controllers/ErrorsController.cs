using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using RelatoriosApi.Models;
using Relatorios.Dominio.Exception;
using System.Net;

namespace RelatoriosApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ApiResponsePadrao Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = 500;

            if (exception is NaoAutorizadoException) code = (int)HttpStatusCode.Unauthorized; 
            //else if (exception is MyUnauthException) code = 401; // Unauthorized
            //else if (exception is MyException) code = 400; // Bad Request

            Response.StatusCode = code; 

            return new ApiResponsePadrao(exception); 
        }
    }    

}
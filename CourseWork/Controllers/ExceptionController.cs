using CourseWork.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route ("error")]
        public object Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context.Error;
            int code = 500;

            if (exception is CustomHttpException httpException)
            {
                code = (int)httpException.StatusCode;
            }

            Response.StatusCode = code;
            return new { exception.Message, code };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Realms.Core.Exceptions;

namespace Tiveriad.Multitenancy.Apis.Filters;

public class ApiExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var multiTenancyException = context.Exception as RealmException;
        var logger =
            context.HttpContext.RequestServices.GetService(typeof(ILogger<ApiExceptionFilter>)) as
                ILogger<ApiExceptionFilter>;

        var message = context.Exception.InnerException!=null
            ? context.Exception.InnerException.Message
            : context.Exception.Message;
        logger?.LogError(message, context.Exception, context.HttpContext.Request);

        if (multiTenancyException != null)

            context.Result = new BadRequestObjectResult(multiTenancyException.Message);
        else
            context.Result = new ObjectResult(context.Exception.Message)
                { StatusCode = StatusCodes.Status500InternalServerError };

        return Task.CompletedTask;
    }
}
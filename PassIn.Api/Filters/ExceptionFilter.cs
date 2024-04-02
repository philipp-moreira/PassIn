using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PassIn.Communication.Responses;
using PassIn.Execeptions;

namespace PassIn.Application.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case PassInExeception:
                HandleProjectException(context);
                break;
            default:
                ThrowUnknowError(context);
                break;
        };
    }

    static void HandleProjectException(ExceptionContext context)
    {
        var bodyResponse = new ResponseErrorJson(context.Exception.Message);

        switch (context.Exception)
        {
            case NotFoundException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new NotFoundObjectResult(bodyResponse);
                break;
            case ErrorOnValidationException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(bodyResponse);
                break;
            case ConflictException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                context.Result = new ConflictObjectResult(bodyResponse);
                break;
            default:
                ThrowUnknowError(context);
                break;
        };
    }

    static void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(context.Exception.Message));
    }
}
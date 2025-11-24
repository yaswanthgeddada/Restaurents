using System;
using Restaurents.Domain.Exceptions;

namespace Restaurents.API.Middlewares;

public class ExceptionHandelingMiddleware(ILogger<ExceptionHandelingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogError(ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError("ERROR FROM EM -  @{0}", ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}

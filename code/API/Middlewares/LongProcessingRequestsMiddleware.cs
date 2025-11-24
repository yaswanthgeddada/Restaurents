using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restaurents.API.Middlewares;

public class LongProcessingRequestsMiddleware(ILogger<LongProcessingRequestsMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds / 1000 > 2)
        {
            logger.LogWarning("Request [{verb}] at {path} took {time}ms",
                context.Request.Method,
                 context.Request.Path,
                  stopwatch.ElapsedMilliseconds
                );
        }
    }
}

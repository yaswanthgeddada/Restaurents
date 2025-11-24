using System;
using Microsoft.AspNetCore.Builder;
using Restaurents.API.Middlewares;
using Restaurents.Application.Extensions;
using Restaurents.Infrastructure.Extensions;
using Serilog;

namespace Restaurents.API.Extensions;

public static class PresentationExtension
{
    public static void AddPresentationExtension(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<ExceptionHandelingMiddleware>();
        builder.Services.AddScoped<LongProcessingRequestsMiddleware>();


        builder.Host.UseSerilog((context, config) =>
        config.ReadFrom.Configuration(context.Configuration));
    }
}

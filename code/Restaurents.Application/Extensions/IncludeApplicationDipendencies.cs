
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurents.Application.UserHttpContext;

namespace Restaurents.Application.Extensions;

public static class IncludeApplicationDipendencies
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var Assembly = typeof(IncludeApplicationDipendencies).Assembly;

        services.AddAutoMapper(Assembly);

        services.AddValidatorsFromAssembly(Assembly)
        .AddFluentValidationAutoValidation();

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}

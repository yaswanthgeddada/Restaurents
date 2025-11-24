using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurents.Domain.Entities;
using Restaurents.Domain.RepositoryInterfaces;
using Restaurents.Infrastructure.Data;
using Restaurents.Infrastructure.Persistance;
using Restaurents.Infrastructure.Repositories.Implementations;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Infrastructure.Extensions;

public static class ServiceCollectionsExtension
{
    public static void AddInfrasctuctureDI(this IServiceCollection services, IConfiguration config)
    {
        // services.AddDbContext<RestaurentDbContext>(opt => opt.UseSqlite(config.GetConnectionString("AzureSqlServerDb")).EnableSensitiveDataLogging());


        services.AddDbContext<RestaurentDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("AzureSqlServerDb")).EnableSensitiveDataLogging(), ServiceLifetime.Transient);
        // services.AddDbContext<RestaurentDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DockerSqlServerDb")).EnableSensitiveDataLogging());

        //add identity dip
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RestaurentDbContext>();

        services.AddScoped<IRestaurentsSeeder, RestaurentsSeeder>();
        services.AddScoped<IRestaurentRepository, RestaurentRepository>();
        services.AddScoped<IDishRepository, DishRepository>();

    }
}

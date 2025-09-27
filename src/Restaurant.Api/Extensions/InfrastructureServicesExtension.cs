
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

namespace Restaurant.Api.Extensions;

public static class InfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                               IConfiguration configuration)
    {
        services.AddDbContext<RestaurantDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

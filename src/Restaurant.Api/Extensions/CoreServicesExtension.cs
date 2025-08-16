using Services;
using Services.Abstraction;

namespace Restaurant.Api.Extensions;

public static class CoreServicesExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
                                                     IConfiguration configuration)
    {
        services.AddScoped<IServiceManager, ServiceManager>();

        return services;
    }
}

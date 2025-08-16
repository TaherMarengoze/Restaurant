
namespace Restaurant.Api.Extensions;

public static class PresentationServicesExtension
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}

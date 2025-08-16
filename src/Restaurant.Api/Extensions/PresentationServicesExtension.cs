
using Microsoft.OpenApi.Models;

namespace Restaurant.Api.Extensions;

public static class PresentationServicesExtension
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureSwagger();

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Restaurant API",
                Version = "v1",
                Description = "API for managing restaurant operations"
            });
        });

        return services;
    }
}

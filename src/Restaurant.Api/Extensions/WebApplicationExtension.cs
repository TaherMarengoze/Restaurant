
using Domain.Contracts;

namespace Restaurant.Api.Extensions;

public static class WebApplicationExtension
{
    public static async Task<WebApplication> RunDbInitializerAsync(this WebApplication app)
    {
        using var scoope = app.Services.CreateScope();
        var dbInitializer = scoope.ServiceProvider
            .GetRequiredService<IDbInitializer>();

        await dbInitializer.InitializeAsync();

        return app;
    }
}

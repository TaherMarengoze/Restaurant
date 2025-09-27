
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DbInitializer(RestaurantDbContext dbContext)
    : IDbInitializer
{
    public async Task InitializeAsync()
    {
        await CheckForPendingMigrationsAsync(dbContext);
    }

    private static async Task CheckForPendingMigrationsAsync(DbContext dbContext)
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}

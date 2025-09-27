
using System.Data;
using System.Text.Json;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DbInitializer(RestaurantDbContext dbContext)
    : IDbInitializer
{
    const string SeedDataPath = "../Persistence/Data/Seeding/";

    public async Task InitializeAsync()
    {
        await CheckForPendingMigrationsAsync(dbContext);

        try
        {
            await SeedEntityAsync<MenuCategory>("menu-category.json", true);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async Task CheckForPendingMigrationsAsync(DbContext dbContext)
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }

    private async Task SeedEntityAsync<TEntity>(string entityFileName,
                                                bool enableIdentityInsert = false)
        where TEntity : class
    {
        if (!dbContext.Set<TEntity>().Any())
        {
            var dataSource = File.ReadAllText(@$"{SeedDataPath}{entityFileName}");
            var entities = JsonSerializer.Deserialize<List<TEntity>>(dataSource);

            if (entities != null && entities.Count != 0)
            {
                if (enableIdentityInsert)
                {
                    var connectionWasClosed = dbContext.Database
                        .GetDbConnection().State == ConnectionState.Closed;

                    if (connectionWasClosed)
                        await dbContext.Database.OpenConnectionAsync();

                    try
                    {
                        await SetIdentityInsertAsync<TEntity>(true);
                        await AddThenSaveAsync(entities);
                        await SetIdentityInsertAsync<TEntity>(false);
                    }
                    finally
                    {
                        if (connectionWasClosed)
                            await dbContext.Database.CloseConnectionAsync();
                    }
                }
                else
                {
                    // Normal seeding without identity insert
                    await AddThenSaveAsync(entities);
                }
            }
        }
    }

    private async Task SetIdentityInsertAsync<TEntity>(bool isOn)
        where TEntity : class
    {
        var tableName = dbContext.Model.FindEntityType(typeof(TEntity))?.GetTableName()
            ?? typeof(TEntity).Name;

        var setting = isOn ? "ON" : "OFF";

        FormattableString command = $"SET IDENTITY_INSERT dbo.[{tableName}] {setting}";

        await dbContext.Database.ExecuteSqlRawAsync(command.ToString());
    }

    private async Task AddThenSaveAsync<TEntity>(List<TEntity> entities)
        where TEntity : class
    {
        await dbContext.Set<TEntity>().AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }
}

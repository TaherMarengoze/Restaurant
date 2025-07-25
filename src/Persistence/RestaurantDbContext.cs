
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
    }

    public DbSet<MenuItem> MenuItems { get; set; }

    public DbSet<MenuCategory> MenuCategories { get; set; }
}

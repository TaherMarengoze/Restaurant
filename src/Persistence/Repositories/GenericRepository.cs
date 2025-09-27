
using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GenericRepository<TModel, TKey>(RestaurantDbContext context)
    : IGenericRepository<TModel, TKey>
    where TModel : BaseModel<TKey>
    where TKey : struct
{
    public async Task<TModel?> GetAsync(TKey id)
    {
        return await context.Set<TModel>().FindAsync(id);
    }

    public async Task<IEnumerable<TModel>> GetAllAsync(
        Expression<Func<TModel, bool>>? predicate = null,
        bool tracked = false)
    {
        // Use the context to access the DbSet for TModel
        var query = tracked ?
            context.Set<TModel>() :
            context.Set<TModel>().AsNoTracking();

        // Apply the predicate if provided
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        // Retrieve all entities asynchronously
        return await query.ToListAsync();
    }
    public async Task AddAsync(TModel entity) => throw new NotImplementedException();
    public void Update(TModel entity) => throw new NotImplementedException();
    public void Delete(TModel entity) => throw new NotImplementedException();
}

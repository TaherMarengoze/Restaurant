
using Domain.Contracts;
using Domain.Models;
using System.Collections.Concurrent;

namespace Persistence.Repositories;

public class UnitOfWork(RestaurantDbContext context) : IUnitOfWork
{
    private ConcurrentDictionary<string, object> repositories;

    public async Task<int> CommitAsync() => await context.SaveChangesAsync();

    public IGenericRepository<TModel, TKey> GetRepository<TModel, TKey>()
        where TModel : BaseModel<TKey>
        where TKey : struct
    {
        repositories ??= new ConcurrentDictionary<string, object>();

        return (IGenericRepository<TModel, TKey>)repositories
            .GetOrAdd(
                key: typeof(TModel).Name,
                value: _ = new GenericRepository<TModel, TKey>(context)
            );
    }
}

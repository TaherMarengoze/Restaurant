
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

    public async Task<IEnumerable<TModel>> GetAllAsync(bool tracked = false) => throw new NotImplementedException();
    public async Task AddAsync(TModel entity) => throw new NotImplementedException();
    public void Update(TModel entity) => throw new NotImplementedException();
    public void Delete(TModel entity) => throw new NotImplementedException();
}

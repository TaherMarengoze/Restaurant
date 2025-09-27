
using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Contracts;

public interface IGenericRepository<TEntity, TKey>
    where TEntity : BaseModel<TKey>
    where TKey : struct
{
    Task<TEntity?> GetAsync(TKey id);

    Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool tracked = false);

    Task AddAsync (TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}

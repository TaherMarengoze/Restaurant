
using Domain.Models;

namespace Domain.Contracts;

public interface IUnitOfWork
{
    public Task<int> CommitAsync();

    IGenericRepository<TModel, TKey> GetRepository<TModel, TKey>()
        where TModel : BaseModel<TKey>
        where TKey : struct;
}

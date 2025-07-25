
namespace Domain.Models;

public class BaseModel<TKey> where TKey : struct
{
    public TKey Id { get; set; }
}


namespace Domain.Models;

public class MenuCategory : BaseModel<int>
{
    public required string Name { get; set; }

    public ICollection<MenuItem> Items { get; set; } = [];
}

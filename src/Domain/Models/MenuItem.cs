
namespace Domain.Models;

public class MenuItem : BaseModel<Guid>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; } = default;

    public string? ImageUrl { get; set; }

    public int MenuCategoryId { get; set; }

    public MenuCategory? MenuCategory { get; set; }
}

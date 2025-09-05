
namespace Contracts.Dto;

public class MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public double Price { get; set; } = default;
    public string? ImageUrl { get; set; }
}

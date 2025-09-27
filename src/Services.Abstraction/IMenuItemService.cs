
using Contracts.Dto;

namespace Services.Abstraction;

public interface IMenuItemService
{
    Task<MenuItemDto> GetMenuItem(Guid id);

    Task<IEnumerable<MenuItemDto>> GetMenuItems(Guid[]? ids = null);
}

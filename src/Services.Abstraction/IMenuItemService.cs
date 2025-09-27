
using Contracts.Commands;
using Contracts.Dto;

namespace Services.Abstraction;

public interface IMenuItemService
{
    Task<Guid?> AddNewMenuItemAsync(MenuItemCommand command);
    Task<MenuItemDto> GetMenuItemAsync(Guid id);

    Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync(Guid[]? ids = null);
}

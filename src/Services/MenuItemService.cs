
using Contracts.Commands;
using Contracts.Dto;
using Domain.Contracts;
using Domain.Models;
using Services.Abstraction;

namespace Services;

public class MenuItemService(IUnitOfWork unitOfWork) : IMenuItemService
{
    public async Task<MenuItemDto> GetMenuItemAsync(Guid id)
    {
        var menuItem = await unitOfWork.GetRepository<MenuItem, Guid>().GetAsync(id)
            ?? throw new Exception($"Menu Item with Id = {id} not found");

        //Map
        MenuItemDto menuItemDto = new()
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            Description = menuItem.Description,
            ImageUrl = menuItem.ImageUrl,
            Price = menuItem.Price,
        };

        return menuItemDto;
    }

    public async Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync(Guid[]? ids = null)
    {
        IEnumerable<MenuItem> menuItems;
        if (ids == null || ids.Length == 0)
        {
            menuItems = await unitOfWork.GetRepository<MenuItem, Guid>().GetAllAsync();
        }
        else
        {
            menuItems = await unitOfWork.GetRepository<MenuItem, Guid>()
                .GetAllAsync(m => ids.Distinct().Contains(m.Id));
        }

        //Map
        var menuItemDtos = menuItems.Select(menuItem => new MenuItemDto
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            Description = menuItem.Description,
            ImageUrl = menuItem.ImageUrl,
            Price = menuItem.Price,
        });

        return menuItemDtos;
    }

    public async Task<Guid?> AddNewMenuItemAsync(MenuItemCommand command)
    {
        var newMenuItemId = Guid.NewGuid();

        // Create a new MenuItem entity
        var newMenuItem = new MenuItem
        {
            Id = newMenuItemId,
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            ImageUrl = command.ImageUrl,
            MenuCategoryId = command.MenuCategoryId
        };

        await unitOfWork.GetRepository<MenuItem, Guid>().AddAsync(newMenuItem);

        // Commit the changes to the database
        if (await unitOfWork.CommitAsync() > 0)
        {
            // Return the ID of the newly created menu item
            return newMenuItemId;
        }

        // If the commit failed, return null
        return null;
    }
}

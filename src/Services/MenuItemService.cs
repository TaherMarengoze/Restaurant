
using Contracts.Dto;
using Domain.Contracts;
using Domain.Models;
using Services.Abstraction;

namespace Services;

public class MenuItemService(IUnitOfWork unitOfWork) : IMenuItemService
{
    public async Task<MenuItemDto> GetMenuItem(Guid id)
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
}

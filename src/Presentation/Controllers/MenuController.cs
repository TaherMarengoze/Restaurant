
using Contracts.Commands;
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers;

[Route("api/menu")]
public class MenuController(IServiceManager serviceManager) : ApiController
{
    [HttpGet("{menuItemId:guid}")]
    public async Task<ActionResult<MenuItemDto>> GetMenuItemAsync(
        [FromRoute] Guid menuItemId)
    {
        var result = await serviceManager.MenuItemService.GetMenuItemAsync(menuItemId);

        return Ok(result);
    }

    [HttpGet("items")]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItemsAsync()
    {
        var result = await serviceManager.MenuItemService.GetMenuItemsAsync();

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<Guid?>> AddMenuItemAsync(
        [FromBody] MenuItemCommand command)
    {
        var result = await serviceManager.MenuItemService.AddNewMenuItemAsync(command);

        return Ok(result);
    }
}

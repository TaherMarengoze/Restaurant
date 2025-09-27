
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public class MenuController(IServiceManager serviceManager) : ApiController
{
    [HttpGet("test")]
    public async Task<ActionResult<string>> TestControllerAsync()
    {
        await Task.Delay(100);

        return Ok($"{nameof(MenuController)}: Test Passed");
    }

    [HttpGet("{menuItemId:guid}")]
    public async Task<ActionResult<MenuItemDto>> GetMenuItemAsync(
        [FromRoute] Guid menuItemId)
    {
        var result = await serviceManager.MenuItemService.GetMenuItem(menuItemId);

        return Ok(result);
    }

    [HttpGet("items")]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItemsAsync()
    {
        var result = await serviceManager.MenuItemService.GetMenuItems();

        return Ok(result);
    }
}

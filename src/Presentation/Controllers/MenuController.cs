
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers;

public class MenuController(IServiceManager serviceManager) : ApiController
{
    [HttpGet]
    [ActionName("test")]
    public async Task<ActionResult<string>> TestControllerAsync()
    {
        await Task.Delay(100);

        return Ok($"{nameof(MenuController)}: Test Passed");
    }

    [HttpGet]
    public async Task<ActionResult<MenuItemDto>> GetMenuItemAsync(Guid menuItemId)
    {
        var result = await serviceManager.MenuItemService.GetMenuItem(menuItemId);

        return Ok(result);
    }
}

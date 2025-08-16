
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class MenuController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<string>> TestControllerAsync()
    {
        await Task.Delay(100);

        return Ok($"{nameof(MenuController)}: Test Passed");
    }
}

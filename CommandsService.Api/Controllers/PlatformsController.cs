using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Api.Controllers;

[ApiController]
[Route("api/commands/[controller]")]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {

    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--> Inbound Post # Command Service");

        return Ok();
    }
}
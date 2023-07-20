using AutoMapper;
using CommandsService.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Api.Controllers;

[ApiController]
[Route("api/commands/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICommandRepo _repository;

    public PlatformsController(IMapper mapper, ICommandRepo repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--> Inbound Post # Command Service");

        return Ok("Inbound Post # Command Service");
    }
}
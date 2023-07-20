using AutoMapper;
using CommandsService.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Api.Controllers;

[ApiController]
[Route("api/commands/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepo _commandRepo;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepo commandRepo, IMapper mapper)
    {
        _commandRepo = commandRepo;
        _mapper = mapper;
    }

}
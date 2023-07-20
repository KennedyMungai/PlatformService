using AutoMapper;
using CommandsService.Api.Data;
using CommandsService.Api.Models;
using CommandsService.Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Api.Controllers;

[ApiController]
[Route("api/platforms/{platformId}/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
    {
        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        var commands = _repository.GetCommandsForPlatform(platformId);

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{commandId:int}", Name = "GetCommandForPlatform")]
    public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
    {
        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        var command = _repository.GetCommand(platformId, commandId);

        if (command == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommandReadDto>(command));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandCreateDto)
    {
        if (commandCreateDto == null)
        {
            return BadRequest();
        }

        if (!_repository.PlatformExists(platformId))
        {
            return NotFound();
        }

        var command = _mapper.Map<Command>(commandCreateDto);

        _repository.CreateCommand(platformId, command);

        return CreatedAtAction(nameof(GetCommandForPlatform), new { platformId, commandId = command.Id }, _mapper.Map<CommandReadDto>(command));
    }
}
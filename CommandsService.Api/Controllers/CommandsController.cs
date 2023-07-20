using AutoMapper;
using CommandsService.Api.Data;
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
}
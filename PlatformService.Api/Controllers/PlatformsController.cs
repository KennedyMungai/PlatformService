using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Api.AsyncDataServices;
using PlatformService.Api.Data;
using PlatformService.Api.Dtos;
using PlatformService.Api.Models;
using PlatformService.Api.SyncDataServices.Http;

namespace PlatformService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;
    private readonly IMessageBusClient _messageBusClient;

    public PlatformsController(
        IPlatformRepo repository,
        IMapper mapper,
        ICommandDataClient commandDataClient,
        IMessageBusClient messageBusClient
        )
    {
        _repository = repository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
        _messageBusClient = messageBusClient;
    }

    [HttpGet(Name = "Get All PLatforms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platformItems = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }

    [HttpGet("{id:int}", Name = "Get Platform By Id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _repository.GetPlatformById(id);

        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatformAsync(PlatformCreateDto platformCreateDto)
    {
        var platformItem = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platformItem);
        _repository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformItem);

        try
        {
            await _commandDataClient.SendPlatformToCommand(platformReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not send synchronously: {ex.Message}");
        }

        // Send Async Message
        try
        {
            var platformPublishedDto = _mapper.Map<PlatformPublishedDto>(platformReadDto);
            platformPublishedDto.Event = "Platform_Published";

            _messageBusClient.PublishNewPlatform(platformPublishedDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not send asynchronously: {ex.Message}");
        }

        return CreatedAtRoute(
            nameof(GetPlatformById),
            new { id = platformItem.Id },
            platformReadDto
        );
    }
}
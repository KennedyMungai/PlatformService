using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Api.Data;
using PlatformService.Api.Dtos;
using PlatformService.Api.Models;

namespace PlatformService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

    [HttpPost(Name = "Create New Platform")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platformItem = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platformItem);
        _repository.SaveChanges();

        return CreatedAtRoute(nameof(GetPlatformById), new { id = platformItem.Id }, _mapper.Map<PlatformReadDto>(platformItem));

    }
}
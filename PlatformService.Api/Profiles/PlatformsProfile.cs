using AutoMapper;
using PlatformService.Api.Dtos;
using PlatformService.Api.Models;

namespace PlatformService.Api.Profiles;


public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        // Source -> Target
        CreateMap<Platform, PlatformReadDto>();

        // Target --> Source
        CreateMap<PlatformCreateDto, Platform>();
    }
}
using AutoMapper;
using CommandsService.Api.Models.Dto;

namespace CommandsService.Api.Models.Profiles;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<Command, CommandReadDto>();
    }
}
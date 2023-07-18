using PlatformService.Api.Dtos;

namespace PlatformService.Api.SyncDataServices.Http;


public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto plat);
}
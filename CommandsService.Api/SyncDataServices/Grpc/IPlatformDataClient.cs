using CommandsService.Api.Models;

namespace CommandsService.Api.SyncDataServices.Grpc;

public interface IPlatformDataClient
{
    IEnumerable<Platform> ReturnAllPlatforms();
}
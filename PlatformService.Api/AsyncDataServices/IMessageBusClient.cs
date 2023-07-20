using PlatformService.Api.Dtos;

namespace PlatformService.Api.AsyncDataServices;

public interface IMessageBusClient
{
    void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
}
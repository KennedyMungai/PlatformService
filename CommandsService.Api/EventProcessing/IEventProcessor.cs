namespace CommandsService.Api.EventProcessing;

public interface IEventProcessor
{
    void ProcessEvent(string message);
}
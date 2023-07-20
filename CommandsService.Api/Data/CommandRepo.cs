using CommandsService.Api.Models;

namespace CommandsService.Api.Data;


public class CommandRepo : ICommandRepo
{
    public void CreateCommand(int platformId, Command command)
    {
        throw new NotImplementedException();
    }

    public void CreatePlatform(Platform platform)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        throw new NotImplementedException();
    }

    public Command GetCommand(int platformId, int commandId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetCommandsForPlatform(int platformId)
    {
        throw new NotImplementedException();
    }

    public bool PlatformExists(int platformId)
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }
}
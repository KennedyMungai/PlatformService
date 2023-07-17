using PlatformService.Api.Models;

namespace PlatformService.Api.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform platform)
    {
        _context.Platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return _context.Platforms.First(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}
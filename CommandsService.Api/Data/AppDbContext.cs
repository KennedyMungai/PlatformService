using CommandsService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Api.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Command> Commands { get; set; }
    public DbSet<Platform> Platforms { get; set; }
}
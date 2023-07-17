using PlatformService.Api.Models;

namespace PlatformService.Api.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine(" ---> Seeding Data");
            context.Platforms.AddRange(
                new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "MySql", Publisher = "Oracle", Cost = "Free" },
                new Platform() { Name = "Linux", Publisher = "Linux Foundation", Cost = "Free" }
            );
        }
        else
        {
            Console.WriteLine(" --> We already have data");
        }
    }
}
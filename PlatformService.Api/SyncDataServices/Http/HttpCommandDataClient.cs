using PlatformService.Api.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.Api.SyncDataServices.Http;


public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;

    public HttpCommandDataClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(plat),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("http://localhost:5100/api/commands/platforms", httpContent);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Sync POST to CommandService was OK!");
        }
        else
        {
            Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
        }
    }
}
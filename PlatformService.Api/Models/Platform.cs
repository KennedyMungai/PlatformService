namespace PlatformService.Api.Models;

using System.ComponentModel.DataAnnotations;

public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string Cost { get; set; }
}
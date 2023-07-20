using System.ComponentModel.DataAnnotations;

namespace CommandsService.Api.Models.Dto;

public class CommandCreateDto
{
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string CommandLine { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class AutoServiceModel
{
    [Required] public string Make { get; set; } = string.Empty;
    [Required] public string Model { get; set; } = string.Empty;
    [Required] public string Year { get; set; } = string.Empty;
    public int Miles { get; set; }
    public DateOnly? DateLastServiced { get; set; }
    public string? Notes { get; set; }
}
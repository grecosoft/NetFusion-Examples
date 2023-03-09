namespace Examples.RabbitMQ.WebApi.Models;

public class AutoServiceModel
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public int Miles { get; set; }
    public DateOnly? DateLastServiced { get; set; }
    public string? Notes { get; set; }
}
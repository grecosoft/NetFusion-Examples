using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class AutoSalesModel
{
    [Required] public string Make { get; set; } = string.Empty;
    [Required] public string Model { get; set; } = string.Empty;
    [Required] public string Color { get; set; } = string.Empty;
    public int Year { get; set; } 
    public bool IsNew { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Examples.ServiceBus.Infra.Plugin.Modules;

public class PropertySoldModel
{
    [Required] public string Address { get; set; } = string.Empty;
    [Required] public string City { get; set; } = string.Empty;
    [Required] public string State { get; set; } = string.Empty;
    [Required] public string Zip { get; set; } = string.Empty;
    
    public decimal AskingPrice { get; init; }
    public decimal SoldPrice { get; init; }
}
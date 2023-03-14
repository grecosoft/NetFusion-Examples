using System.ComponentModel.DataAnnotations;

namespace Examples.ServiceBus.WebApi.Models;

public class PropertyTaxModel
{
    [Required]
    public string Address { get; set; } = string.Empty;
    
    [Required]
    public string City { get; set; } = string.Empty;
    
    [Required]
    public string State { get; set; } = string.Empty;
    
    [Required]
    public string Zip { get; set; } = string.Empty;
}
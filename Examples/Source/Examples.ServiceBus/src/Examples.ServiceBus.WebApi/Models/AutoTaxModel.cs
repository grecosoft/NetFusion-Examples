using System.ComponentModel.DataAnnotations;

namespace Examples.ServiceBus.WebApi.Models;

public class AutoTaxModel
{
    [Required]
    public string Vin { get; set; }  = string.Empty;
    
    [Required]
    public string ZipCode { get; set; }  = string.Empty;
}
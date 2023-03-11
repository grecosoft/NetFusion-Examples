using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class AutoTax
{
    [Required]
    public string Vin { get; set; }  = string.Empty;
    
    [Required]
    public string ZipCode { get; set; }  = string.Empty;
}
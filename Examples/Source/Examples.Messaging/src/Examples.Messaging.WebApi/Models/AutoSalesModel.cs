using System.ComponentModel.DataAnnotations;

namespace Examples.Messaging.WebApi.Models;

public class AutoSalesModel
{
    [Required] public string Make { get; set; } = string.Empty;
    [Required] public string Model { get; set; } = string.Empty;
    public int Year { get; set; } 
}
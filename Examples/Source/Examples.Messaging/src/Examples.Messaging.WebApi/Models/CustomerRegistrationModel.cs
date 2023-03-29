using System.ComponentModel.DataAnnotations;

namespace Examples.Messaging.WebApi.Models;

public class CustomerRegistrationModel
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
}
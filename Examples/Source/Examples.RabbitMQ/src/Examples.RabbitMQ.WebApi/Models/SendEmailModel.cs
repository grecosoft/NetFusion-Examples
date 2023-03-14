using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class SendEmailModel
{
    [Required] public string Subject { get; set; } = string.Empty;
    [Required] public string FromAddress { get; set; } = string.Empty;
    [Required] public string[] ToAddresses { get; set; } = Array.Empty<string>();
    [Required] public string Message { get; set; } = string.Empty;
}
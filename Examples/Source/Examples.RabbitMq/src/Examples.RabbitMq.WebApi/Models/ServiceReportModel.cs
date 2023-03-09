using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class ServiceReportModel
{
    [Required] public string CorrelationId { get; set; } = string.Empty;
    [Required] public string[] RequiredServices { get; set; } = Array.Empty<string>();
    public decimal TotalCost { get; set; }
}
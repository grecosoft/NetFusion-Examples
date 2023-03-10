using System.ComponentModel.DataAnnotations;

namespace Examples.RabbitMQ.WebApi.Models;

public class ConfigurationModel
{
    [Required] public string MinLogLevel { get; set; } = string.Empty;
    public bool ClearStatistics { get; set; }
    public int RestoreAfterSeconds { get; set; }
}
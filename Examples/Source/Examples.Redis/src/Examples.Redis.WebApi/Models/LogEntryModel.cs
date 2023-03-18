using System.ComponentModel.DataAnnotations;

namespace Examples.Redis.WebApi.Models;

public class LogEntryModel
{
    [Required] 
    public string LogLevel { get; set; } = string.Empty;
    public int Severity { get; set; }
    public string? Message { get; set; }
}
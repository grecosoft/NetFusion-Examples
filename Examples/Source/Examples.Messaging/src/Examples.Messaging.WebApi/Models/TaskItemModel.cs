using System.ComponentModel.DataAnnotations;

namespace Examples.Messaging.WebApi.Models;

public class TaskItemModel
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    public DateTime DateDue { get; set; }
    public bool IsBlocked { get; set; }
}
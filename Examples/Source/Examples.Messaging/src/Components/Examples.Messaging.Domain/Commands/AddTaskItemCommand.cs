using System;
using NetFusion.Messaging.Types;

namespace Examples.Messaging.Domain.Commands;

public class AddTaskItemCommand : Command<string>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime DateDue { get; }
    public bool IsBlocked { get; }
    
    public AddTaskItemCommand(string name, string description, DateTime dateDue, bool isBlocked)
    {
        Name = name;
        Description = description;
        DateDue = dateDue;
        IsBlocked = isBlocked;
    }
}


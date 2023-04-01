using System;
using NetFusion.Messaging.Types;

namespace Examples.Messaging.Domain.Events;

public class ImportantTaskCreated : DomainEvent
{
    public string TaskId { get; }
    public string TaskName { get; }
    public DateTime DateDue { get; }
    public int NumberDaysTillDue { get; }
    
    public ImportantTaskCreated(string taskId, string taskName, DateTime dateDue, int numberDaysTillDue)
    {
        TaskId = taskId;
        TaskName = taskName;
        DateDue = dateDue;
        NumberDaysTillDue = numberDaysTillDue;
    }
}
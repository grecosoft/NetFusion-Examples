using System;
using Examples.Messaging.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.Messaging.App.Handlers;

public class TaskReminderHandler
{
    public void OnSendReminder(ImportantTaskCreated domainEvent)
    {
        if (domainEvent.NumberDaysTillDue < 0)
        { 
            throw new InvalidOperationException("Invalid number of days.");
        }
        
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
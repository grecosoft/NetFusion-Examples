using System;
using Examples.Redis.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.Redis.App.Handlers;

public class LogEntryHandler
{
    public void OnLogCreated(LogEntryCreated domainEvent)
    {
        Console.WriteLine($"{nameof(LogEntryHandler)}:{nameof(OnLogCreated)} Called");
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
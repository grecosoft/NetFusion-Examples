using NetFusion.Messaging.Types;

namespace Examples.Redis.Domain.Events;

public class LogEntryCreated : DomainEvent
{
    public string LogLevel { get; }
    public int Severity { get; }
    public string? Message { get; init; }

    public LogEntryCreated(string logLevel, int severity)
    {
        LogLevel = logLevel;
        Severity = severity;
    }
}
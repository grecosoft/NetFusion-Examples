using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Events;

public class ConfigurationUpdated : DomainEvent
{
    public string MinLogLevel { get; }
    public bool ClearStatistics { get; }
    public int RestoreAfterSeconds { get; }

    public ConfigurationUpdated(string minLogLevel, bool clearStatistics, int restoreAfterSeconds)
    {
        MinLogLevel = minLogLevel;
        ClearStatistics = clearStatistics;
        RestoreAfterSeconds = restoreAfterSeconds;
    }
}
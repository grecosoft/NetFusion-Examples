using System;
using Examples.RabbitMQ.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class ConfigurationHandler
{
    public void OnConfigurationUpdate(ConfigurationUpdated domainEvent)
    {
        Console.WriteLine(nameof(OnConfigurationUpdate));
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
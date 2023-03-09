using System;
using Examples.RabbitMQ.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class ServiceReportHandler
{
    public void OnServiceReportReceived(ServiceReport command)
    {
        Console.WriteLine(nameof(OnServiceReportReceived));
        Console.WriteLine(command.ToIndentedJson());
    }
}
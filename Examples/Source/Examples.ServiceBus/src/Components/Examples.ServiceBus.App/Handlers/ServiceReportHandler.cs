using System;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

public class ServiceReportHandler
{
    public void OnServiceReportReceived(ServiceReport command)
    {
        Console.WriteLine(nameof(OnServiceReportReceived));
        Console.WriteLine(command.ToIndentedJson());
    }
}
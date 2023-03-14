using System;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

public class CarFaxReportHandler
{
    public void ReportGenerated(CarFaxReport command)
    {
        Console.WriteLine(nameof(CarFaxReportHandler));
        Console.WriteLine(command.ToIndentedJson());
    }
}
using System;
using Examples.RabbitMQ.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class CarFaxReportHandler
{
    public void ReportGenerated(CarFaxReport command)
    {
        Console.WriteLine(nameof(CarFaxReportHandler));
        Console.WriteLine(command.ToIndentedJson());
    }
}
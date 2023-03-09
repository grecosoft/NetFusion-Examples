using System;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

public class CarFaxResultHandler
{
    public void OnReportResult(CarFaxResult result)
    {
        Console.WriteLine(result.ToIndentedJson());
    }
}
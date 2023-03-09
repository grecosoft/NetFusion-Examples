using System;
using Examples.RabbitMq.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMq.App.Handlers;

public class CarFaxHandler
{
    public CarFaxSummary GenerateCarFax(GenerateCarFax command)
    {
        return command.State switch
        {
            "CT" => new CarFaxSummary("Volvo", "970", 1989, 100),
            "NC" => new CarFaxSummary("Audi", "R8", 2017, 350),
            _ => new CarFaxSummary("Yugo", "GL", 1987, 1)
        };
    }

    public void ReportGenerated(CarFaxSummary summary)
    {
        Console.WriteLine(summary.ToIndentedJson());
    }
}
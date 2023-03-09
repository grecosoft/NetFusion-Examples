using System;
using Examples.RabbitMQ.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class CarFaxGenerationHandler
{
    public CarFaxReport GenerateCarFax(GenerateCarFaxReport command)
    {
        Console.WriteLine(nameof(CarFaxReportHandler));
        Console.WriteLine(command.ToIndentedJson());
        
        return command.State switch
        {
            "CT" => new CarFaxReport("Volvo", "970", 1989, 100),
            "NC" => new CarFaxReport("Audi", "R8", 2017, 350),
            _ => new CarFaxReport("Yugo", "GL", 1987, 1)
        };
    }
}
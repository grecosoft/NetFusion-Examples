using System;
using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Commands;

public class GenerateServiceReport : Command<ServiceReport>
{
    public string Make { get; }
    public string Model { get; }
    public string Year { get; }
    public int Miles { get; }
    
    public DateOnly? DateLastServiced { get; set; }
    public string? Notes { get; set; }

    public GenerateServiceReport(string make, string model, string year, int miles)
    {
        Make = make;
        Model = model;
        Year = year;
        Miles = miles;
    }
}
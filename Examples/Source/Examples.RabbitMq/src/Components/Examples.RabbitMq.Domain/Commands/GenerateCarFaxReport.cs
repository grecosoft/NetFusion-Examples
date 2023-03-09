using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Commands;

public class GenerateCarFaxReport : Command<CarFaxReport>
{   
    public string Vin { get; }
    public string State { get; }

    public GenerateCarFaxReport(string vin, string state)
    {
        Vin = vin;
        State = state;
    }
}
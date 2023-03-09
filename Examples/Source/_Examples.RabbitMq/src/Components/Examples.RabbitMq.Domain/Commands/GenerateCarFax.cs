using NetFusion.Messaging.Types;

namespace Examples.RabbitMq.Domain.Commands;

public class GenerateCarFax : Command<CarFaxSummary>
{   
    public string Vin { get; set; }
    public string State { get; set; }

    public GenerateCarFax(string vin, string state)
    {
        Vin = vin;
        State = state;
    }
}
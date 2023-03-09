using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Commands;

public class  GenerateCarFax : Command<CarFaxResult>
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    
    public GenerateCarFax(string make, string model)
    {
        Make = make;
        Model = model;
    }
}
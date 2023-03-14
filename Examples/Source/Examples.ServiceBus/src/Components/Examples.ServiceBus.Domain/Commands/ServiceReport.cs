using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Commands;

public class ServiceReport : Command
{
    public string Make { get; }
    public string Model { get; }
    public decimal TotalCost { get; }
    public string[] ServiceItems { get; }

    public ServiceReport(string make, string model, decimal totalCost, string[] serviceItems)
    {
        Make = make;
        Model = model;
        TotalCost = totalCost;
        ServiceItems = serviceItems;
    }
}
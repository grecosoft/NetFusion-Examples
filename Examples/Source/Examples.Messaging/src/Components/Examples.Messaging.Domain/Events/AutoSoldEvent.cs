using NetFusion.Messaging.Types;

namespace Examples.Messaging.Domain.Events;

public class AutoSoldEvent: DomainEvent
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }

    public AutoSoldEvent(
        string make,
        string model,
        int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
}
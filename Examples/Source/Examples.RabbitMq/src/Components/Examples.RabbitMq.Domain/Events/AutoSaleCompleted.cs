using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Events;

public class AutoSaleCompleted : DomainEvent
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public string? Color { get; init; }
    public bool? IsNew { get; init; }

    public AutoSaleCompleted(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
}
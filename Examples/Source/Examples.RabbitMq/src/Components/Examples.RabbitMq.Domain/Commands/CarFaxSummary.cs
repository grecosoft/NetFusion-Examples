using NetFusion.Messaging.Types;

namespace Examples.RabbitMq.Domain.Commands;

public class CarFaxSummary : Command
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public int Score { get; }
    
    public CarFaxSummary(string make, string model, int year, int score)
    {
        Make = make;
        Model = model;
        Year = year;
        Score = score;
    }
}
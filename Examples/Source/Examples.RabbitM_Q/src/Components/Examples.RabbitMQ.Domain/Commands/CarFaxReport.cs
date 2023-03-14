using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Commands;

public class CarFaxReport : Command
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }
    public int Score { get; }
    
    public CarFaxReport(string make, string model, int year, int score)
    {
        Make = make;
        Model = model;
        Year = year;
        Score = score;
    }
}
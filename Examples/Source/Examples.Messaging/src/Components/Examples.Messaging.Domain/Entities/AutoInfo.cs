namespace Examples.Messaging.Domain.Entities;

public class AutoInfo
{
    public string Make { get; }
    public string Model { get; }
    public int Year { get; }

    public AutoInfo(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
}
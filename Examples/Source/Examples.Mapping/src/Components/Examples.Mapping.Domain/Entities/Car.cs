namespace Examples.Mapping.Domain.Entities;

public class Car
{
    public string Make { get; }
    public string Model { get; }
    public decimal Price { get; }
    public string Color { get; }
    public int Year { get;}

    public Car(string make, string model, decimal price, string color, int year)
    {
        Make = make;
        Model = model;
        Price = price;
        Color = color;
        Year = year;
    }

    // Don't expose theses on the model :)
    public bool HasSalvageTitle { get; init; }
    public bool WasSmokerCar { get; init;}
}
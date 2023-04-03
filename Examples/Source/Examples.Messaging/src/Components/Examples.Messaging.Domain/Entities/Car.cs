namespace Examples.Messaging.Domain.Entities;

public class Car
{
    public string Make { get; set; } 
    public string Model { get; set; } 
    public string Color { get; set; } 
    public decimal Price { get; set; }
    public int Year { get; set;}

    public Car(
        string make,
        string model,
        string color, 
        decimal price,
        int year)
    {
        Make = make;
        Model = model;
        Color = color;
        Price = price;
        Year = year;
    }
}
namespace Examples.Mapping.Domain.Entities;

public class Printer
{
    public string Make { get; }
    public string Model { get; }
    public string Description { get; }
    public decimal Price { get; }
    public bool IsColor { get; init; }
    
    public Printer(string make, string model, string description, decimal price)
    {
        Make = make;
        Model = model;
        Description = description;
        Price = price;
    }
}
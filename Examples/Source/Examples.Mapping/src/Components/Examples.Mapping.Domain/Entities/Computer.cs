using System;

namespace Examples.Mapping.Domain.Entities;

public class Computer
{
    public string Make { get; }
    public string Model { get; }
    public int Ram { get; }
    public DateTime DateBuilt { get; }
    
    public Computer(string make, string model, int ram, DateTime dateBuilt)
    {
        Make = make;
        Model = model;
        Ram = ram;
        DateBuilt = dateBuilt;
    }
}
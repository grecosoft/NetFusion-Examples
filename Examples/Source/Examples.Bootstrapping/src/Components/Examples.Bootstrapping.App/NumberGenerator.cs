using System;
using Examples.Bootstrapping.CrossCut;

namespace Examples.Bootstrapping.App;

public class NumberGenerator : INumberGenerator
{
    public int GenerateNumber()
    {
        Random r = new Random();
        return r.Next(0, 100);
    }
}
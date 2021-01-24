using System;
using Core.Component;

namespace App.Component
{
    public class NumberGenerator : INumberGenerator
    {
        public int GenerateNumber()
        {
            Random r = new Random();
            return r.Next(0, 100);
        }
    }
}

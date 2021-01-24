using System;
using Core.Component;

namespace WebApiHost
{
    public class NumberGenerator : INumberGenerator
    {
        public int GenerateNumber()
        {
            Random r = new Random();
            return r.Next(200, 300);
        }
    }
}

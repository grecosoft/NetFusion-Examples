using System.Collections.Generic;
using Core.Component;

namespace App.Component
{
    public class ValidNumberComponent : IValidNumbers
    {
        public IEnumerable<int> GetValidNumbers() => new[] {888, 999, 1111};
    }
}
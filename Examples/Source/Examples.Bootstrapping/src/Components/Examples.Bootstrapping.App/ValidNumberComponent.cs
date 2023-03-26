using System.Collections.Generic;
using Examples.Bootstrapping.CrossCut;

namespace Examples.Bootstrapping.App;

public class ValidNumberComponent : IValidNumbers
{
    public IEnumerable<int> GetValidNumbers() => new[] {888, 999, 1111};
}
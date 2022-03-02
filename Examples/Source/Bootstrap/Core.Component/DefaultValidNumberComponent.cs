using System.Collections.Generic;

namespace Core.Component
{
    public class DefaultValidNumberComponent : IValidNumbers
    {
        public IEnumerable<int> GetValidNumbers() => new[] {100, 200, 300};
    }
}

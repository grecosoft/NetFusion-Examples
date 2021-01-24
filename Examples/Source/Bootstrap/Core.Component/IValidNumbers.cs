using System.Collections.Generic;

namespace Core.Component
{
    public interface IValidNumbers
    {
        IEnumerable<int> GetValidNumbers();
    }
}
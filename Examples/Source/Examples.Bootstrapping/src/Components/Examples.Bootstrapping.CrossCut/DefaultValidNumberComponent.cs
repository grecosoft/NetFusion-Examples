namespace Examples.Bootstrapping.CrossCut;

public class DefaultValidNumberComponent : IValidNumbers
{
    public IEnumerable<int> GetValidNumbers() => new[] {100, 200, 300};
}
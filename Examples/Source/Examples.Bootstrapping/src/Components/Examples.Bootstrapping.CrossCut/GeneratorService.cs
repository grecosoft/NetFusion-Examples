namespace Examples.Bootstrapping.CrossCut;

public class GeneratorService
{
    private readonly IEnumerable<INumberGenerator> _generators;

    public GeneratorService(IEnumerable<INumberGenerator> generators)
    {
        _generators = generators;
    }

    public int[] GetRandomNumbers() => _generators.Select(g => g.GenerateNumber()).ToArray();
}
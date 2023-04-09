using Examples.Mapping.Domain.Entities;
using Examples.Mapping.WebApi.Models;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Mappings;

public class ProductMappings : IMappingStrategyFactory
{
    public IEnumerable<IMappingStrategy> GetStrategies()
    {
        yield return DelegateMap.Map((Computer entity) => new ProductSummary
        {
            Make = entity.Make,
            Model = entity.Model,
            Description = $"Ram: {entity.Ram}, Date Built: {entity.DateBuilt}"
        });
        
        yield return DelegateMap.Map((Printer entity) => new ProductSummary
        {
            Make = entity.Make,
            Model = entity.Model,
            Description = $"Color: {entity.IsColor}, Price: {entity.Price}"
        });
    }
}
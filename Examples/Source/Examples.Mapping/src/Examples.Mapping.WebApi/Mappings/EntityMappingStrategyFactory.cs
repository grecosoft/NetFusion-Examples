using Examples.Mapping.Domain.Entities;
using Examples.Mapping.WebApi.Models;
using Nelibur.ObjectMapper;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Mappings;

public class EntityMappingStrategyFactory : IMappingStrategyFactory
{
    static EntityMappingStrategyFactory()
    {
        TinyMapper.Bind<Car, CarSummary>();
    }

    public IEnumerable<IMappingStrategy> GetStrategies()
    {
        yield return DelegateMap.Map((Car c) => TinyMapper.Map<CarSummary>(c));
    }
}
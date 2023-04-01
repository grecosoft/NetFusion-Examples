using Examples.MongoDB.Domain.Entities;
using NetFusion.Integration.MongoDB;

namespace Examples.MongoDB.Infra.Repositories;

public class StateInfoMap : EntityClassMap<StateInfo>
{
    public StateInfoMap()
    {
        CollectionName = "info.states";
        AutoMap();
        MapStringPropertyToObjectId(m => m.Id);
    }
}
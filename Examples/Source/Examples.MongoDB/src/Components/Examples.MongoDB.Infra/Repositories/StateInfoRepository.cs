using System.Linq;
using System.Threading.Tasks;
using Examples.MongoDB.App.Repositories;
using Examples.MongoDB.Domain.Entities;
using MongoDB.Driver;
using NetFusion.Integration.MongoDB;

namespace Examples.MongoDB.Infra.Repositories;

public class StateInfoRepository : IStateInfoRepository
{
    private IMongoCollection<StateInfo> StateInfoColl { get; }

    public StateInfoRepository(IMongoDbClient<GeographicDb> geographicDb)
    {
        this.StateInfoColl = geographicDb.GetCollection<StateInfo>();
    }

    public async Task<string> Add(StateInfo stateInfo)
    {
        await StateInfoColl.InsertOneAsync(stateInfo);
        return stateInfo.Id;
    }

    public async Task<StateInfo?> Read(string state) 
    {
        var results = await StateInfoColl.Find(i => i.State == state)
            .ToListAsync();

        return results.FirstOrDefault();
    }
}
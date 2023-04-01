using System.Threading.Tasks;
using Examples.MongoDB.Domain.Entities;

namespace Examples.MongoDB.App.Repositories;

public interface IStateInfoRepository
{
    Task<string> Add(StateInfo stateInfo);
    Task<StateInfo?> Read(string state);
}
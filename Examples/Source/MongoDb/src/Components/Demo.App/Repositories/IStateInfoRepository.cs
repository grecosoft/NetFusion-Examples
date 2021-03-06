using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.App.Repositories
{
    public interface IStateInfoRepository
    {
        Task<string> Add(StateInfo stateInfo);
        Task<StateInfo> Read(string state);
    }
}

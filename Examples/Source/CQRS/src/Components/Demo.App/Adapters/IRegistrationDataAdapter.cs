using Demo.Domain.Entities;
using System.Threading.Tasks;

namespace Demo.App.Adapters
{
    public interface IRegistrationDataAdapter
    {
        Task<AutoInfo[]> GetValidModelsAsync(int forYear);
    }
}

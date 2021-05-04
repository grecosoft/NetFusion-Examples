using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.App.Adapters
{
    public interface IRegistrationDataAdapter
    {
        Task<AutoInfo[]> GetValidModelsAsync(int forYear);
    }
}

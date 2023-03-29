using System.Threading.Tasks;
using Examples.Messaging.Domain.Entities;

namespace Examples.Messaging.App.Adapters;

public interface IRegistrationDataAdapter
{
    Task<AutoInfo[]> GetValidModelsAsync(int forYear);
}
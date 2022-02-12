using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.App.Adapters
{
    public interface ISalesDataAdapter
    {
        Task<AutoSalesInfo[]> GetInventory(string make, int year);
    }
}

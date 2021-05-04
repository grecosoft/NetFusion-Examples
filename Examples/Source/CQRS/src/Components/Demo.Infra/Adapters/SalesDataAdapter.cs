using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Demo.App.Adapters;
using Demo.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Demo.Infra.Adapters
{
    public class SalesDataAdapter : ISalesDataAdapter
    {
        private readonly ILogger _logger;

        public SalesDataAdapter(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Registration Adapter");
        }

        public async Task<AutoSalesInfo[]> GetInventory(string make, int year)
        {
            _logger.LogDebug("Attempting to download data...");

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(
                @"https://raw.githubusercontent.com/grecosoft/NetFusion-Examples/master/Examples/Data/inventory.json");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            _logger.LogDebug(responseBody);

            var data = JsonSerializer.Deserialize<InventoryResponse>(responseBody);
            return data.SalesInfo.Where(s => s.Make == make && s.Year == year).ToArray();
        }

        private class InventoryResponse
        {
            public AutoSalesInfo[] SalesInfo { get; set; }
        }
    }
}

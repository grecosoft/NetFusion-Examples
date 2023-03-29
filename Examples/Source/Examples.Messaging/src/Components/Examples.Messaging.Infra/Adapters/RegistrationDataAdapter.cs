using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Examples.Messaging.App.Adapters;
using Examples.Messaging.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Examples.Messaging.Infra.Adapters;

public class RegistrationDataAdapter : IRegistrationDataAdapter
{
    private readonly ILogger _logger;

    public RegistrationDataAdapter(
        ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("Registration Adapter");
    }

    public async Task<AutoInfo[]> GetValidModelsAsync(int forYear)
    {
        _logger.LogDebug("Attempting to download data...");

        var httpClient = new HttpClient();

        HttpResponseMessage response = await httpClient.GetAsync(
            @"https://raw.githubusercontent.com/grecosoft/NetFusion-Examples/master/Examples/Data/valid_autos.json");

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<AutoRegDataResponse>(responseBody, 
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        var results = data == null ? Array.Empty<AutoInfo>() : 
            data.AutoInfo.Where(a => a.Year == forYear).ToArray();
        
        _logger.LogDebug("Retrieved {numberResults} results.", results.Length);

        return results;
    }

    private class AutoRegDataResponse
    {
        public AutoInfo[] AutoInfo { get; set; } = Array.Empty<AutoInfo>();
    }
}
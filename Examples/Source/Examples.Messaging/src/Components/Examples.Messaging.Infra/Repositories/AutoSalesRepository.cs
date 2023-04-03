using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Threading.Tasks;
using Examples.Messaging.Domain.Entities;
using Examples.Messaging.Domain.Queries;
using Microsoft.Extensions.Logging;

namespace Examples.Messaging.Infra.Repositories;

public class AutoSalesRepository
{
    private readonly ILogger _logger;

    public AutoSalesRepository(
        ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("Auto Sales Repository");
    }

    public async Task<Car[]> OnQuery(CarSalesQuery query)
    {
        _logger.LogDebug("Attempting to download data...");

        var httpClient = new HttpClient();

        HttpResponseMessage response = await httpClient.GetAsync(
            @"https://raw.githubusercontent.com/grecosoft/NetFusion-Examples/master/Examples/Data/inventory.json");

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<InventoryResponse>(responseBody, 
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        if (data == null) return Array.Empty<Car>();
            
        return data.SalesInfo 
            .Where(s => s.Make == query.Make && s.Year == query.Year)
            .Where(s => 
                !string.IsNullOrWhiteSpace(s.Make) &&
                !string.IsNullOrWhiteSpace(s.Make) && 
                !string.IsNullOrWhiteSpace(s.Color))
            .Select(s => new Car(s.Make!, s.Model!, s.Color!, s.Price, s.Year))
            .ToArray();
    }
    
    private class InventoryResponse
    {
        public AutoSalesInfo[] SalesInfo { get; set; } = Array.Empty<AutoSalesInfo>();
    }
    
    private class AutoSalesInfo
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set;}
    }
}
using System;
using System.Collections.Concurrent;
using Examples.ServiceBus.App.Services;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Messaging.Types.Attributes;

namespace Examples.ServiceBus.Infra.Repositories;

public class PendingAutoServiceRepository : IPendingAutoServiceRepository
{
    private readonly ConcurrentDictionary<string, GenerateServiceReport> _requests = new();

    public void Add(GenerateServiceReport serviceRequest)
    {
        var correlationId = serviceRequest.GetCorrelationId();
        if (string.IsNullOrWhiteSpace(correlationId))
        {
            Console.WriteLine("Request has not correlation identifier.");
            return;
        }

        if (_requests.TryAdd(correlationId, serviceRequest))
        {
            Console.WriteLine("Request save for future processing.");

        }
    }

    public void Remove(string correlationId)
    {
        if (_requests.TryRemove(correlationId, out var serviceRequest))
        {
            Console.WriteLine($"Service request completed:  {serviceRequest.Make} / {serviceRequest.Model}");
        }
    }

    public GenerateServiceReport? Get(string correlationId)
    {
        if (!_requests.TryGetValue(correlationId, out var serviceRequest))
        {
            Console.WriteLine($"Pending service report for: {correlationId} not found.");
        }

        return serviceRequest;
    }
}
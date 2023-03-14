using Examples.ServiceBus.Domain.Commands;

namespace Examples.ServiceBus.App.Services;

public interface IPendingAutoServiceRepository
{
    public void Add(GenerateServiceReport serviceRequest);
    public void Remove(string correlationId);
    public GenerateServiceReport? Get(string correlationId);
}
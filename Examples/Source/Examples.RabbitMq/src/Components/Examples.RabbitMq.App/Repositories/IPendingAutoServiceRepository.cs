using Examples.RabbitMQ.Domain.Commands;

namespace Examples.RabbitMQ.App.Repositories;

public interface IPendingAutoServiceRepository
{
    public void Add(GenerateServiceReport serviceRequest);
    public void Remove(string correlationId);
    public GenerateServiceReport? Get(string correlationId);
}
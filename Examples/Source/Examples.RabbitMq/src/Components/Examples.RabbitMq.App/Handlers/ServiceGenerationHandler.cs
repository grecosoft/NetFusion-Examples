using System;
using Examples.RabbitMQ.App.Repositories;
using Examples.RabbitMQ.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class ServiceGenerationHandler
{
    private readonly IPendingAutoServiceRepository _serviceRepository;

    public ServiceGenerationHandler(IPendingAutoServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public void OnGenerateServiceReport(GenerateServiceReport command)
    {
        Console.WriteLine(nameof(OnGenerateServiceReport));
        Console.WriteLine(command.ToIndentedJson());
        
        _serviceRepository.Add(command);
    }
}
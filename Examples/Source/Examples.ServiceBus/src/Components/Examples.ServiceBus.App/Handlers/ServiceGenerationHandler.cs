using System;
using Examples.ServiceBus.App.Services;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

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
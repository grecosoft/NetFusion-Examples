using Examples.ServiceBus.App.Handlers;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Base;
using NetFusion.Integration.ServiceBus;

namespace Examples.ServiceBus.Infra;

public class ServiceBusRouter : NamespaceRouter
{
    public ServiceBusRouter() : base("TestNetFusionNamespace")
    {
    }

    protected override void OnDefineEntities()
    {
        // Microservice 1:
        
        DefineQueueWithResponse<GenerateCarFax, CarFaxResult>(route => route.ToConsumer<CarFaxHandler>(
            c => c.GenerateReport,
            meta =>
            {
                meta.QueueName = "reports";
                meta.MaxDeliveryCount = 6;
                meta.RequiresSession = false;
            }));
        
        // Microservice 2:
        RouteToQueueWithResponse<GenerateCarFax, CarFaxResult>(
            "reports",
            route => route.ToConsumer<CarFaxResultHandler>(c => c.OnReportResult,
                meta =>
                {
                    meta.QueueName = "ReportResponses";
                }),
            options =>
            {
                options.ContentType = ContentTypes.Json;
            });
    }
}
using EasyNetQ.Topology;
using Examples.RabbitMQ.App.Handlers;
using Examples.RabbitMQ.Domain.Commands;
using Examples.RabbitMQ.Domain.Events;
using NetFusion.Integration.RabbitMQ;

namespace Examples.RabbitMQ.Infra;

public class RabbitMqBusRouter : RabbitMqRouter
{
    public RabbitMqBusRouter() : base("testBus")
    {
    }


    protected override void OnDefineEntities()
    {
        // Publishing Microservice:
        // ------------------------------------------------
        DefineExchange<PropertySold>(exchange =>
        {
            exchange.ExchangeType = ExchangeType.Direct;
            exchange.ExchangeName = "RealEstate";
            exchange.RouteKey(e => e.State);
            exchange.WhenDomainEvent(e => e.Zip != "15068");
        });
        
        DefineExchange<AutoSaleCompleted>(exchange =>
        {
            exchange.ExchangeType = ExchangeType.Topic;
            exchange.ExchangeName = "CompletedAutoSales";
            exchange.AlternateExchangeName = "NonRouted_CompletedAutoSales";
            exchange.WhenDomainEvent(m => m.Make != "Yugo");
            exchange.RouteKey( m => $"{m.Make}.{m.Model}.{m.Year}");
        });

        RouteToQueue<SendEmail>("ProcessEmails");
        
        RouteToQueueWithResponse<GenerateCarFaxReport, CarFaxReport>("GenerateCarFaxReports", route =>
        {
            route.ToConsumer<CarFaxReportHandler>(c => c.ReportGenerated, queue =>
            {
                queue.QueueName = "CompletedCarFaxReports";
            });
        });
        
        RouteToQueueWithResponse<GenerateServiceReport, ServiceReport>("GenerateCarServiceReports",
            route => route.ToConsumer<ServiceReportHandler>(
                c => c.OnServiceReportReceived, 
                queue => queue.QueueName = "FinishedServiceReports") );
        
            
        // Subscribing Microservice:
        // ------------------------------------------------
        SubscribeToExchange<PropertySold>("RealEstate", 
            new []{ "CT", "NY", "NH", "ME" }, 
            route => route.ToConsumer<RealEstateHandler>(
                c => c.OnNorthEastProperty,
                queue =>
                {
                    queue.QueueName = "NorthEastProperties";
                }));
        
        SubscribeToExchange<PropertySold>("RealEstate", 
            new []{ "NC", "SC", "FL" }, 
            route => route.ToConsumer<RealEstateHandler>(
                c => c.OnSouthEastProperty,
                queue =>
                {
                    queue.QueueName = "SouthEastProperties";
                }));
        
        SubscribeToExchange<AutoSaleCompleted>("CompletedAutoSales",
            new[] {"VW.*.2017", "BMW.*.2018" },
            route =>
            {
                route.ToConsumer<AutoSalesHandler>(c => c.OnGermanAutoSales,
                    meta =>
                    {
                        meta.QueueName = "GermanAutosSales";
                    });
            });
        
        SubscribeToExchange<AutoSaleCompleted>("CompletedAutoSales",
            new[] {"Chevy.Corvette.*", "Buick.*.2019" },
            route =>
            {
                route.ToConsumer<AutoSalesHandler>(c => c.OnAmericanAutoSales,
                    meta =>
                    {
                        meta.QueueName = "AmericanAutosSales";
                    });
            });
        
        DefineQueue<SendEmail>(route =>
        {
            route.ToConsumer<EmailHandler>(c => c.OnSendEmail, queue =>
            {
                queue.QueueName = "ProcessEmails";
            });
        });
        
        DefineQueueWithResponse<GenerateCarFaxReport, CarFaxReport>(route =>
        {
            route.ToConsumer<CarFaxGenerationHandler>(c => c.GenerateCarFax, queue =>
            {
                queue.QueueName = "GenerateCarFaxReports";
            });
        });

        DefineQueue<GenerateServiceReport>(route =>
        {
            route.ToConsumer<ServiceGenerationHandler>(
                c => c.OnGenerateServiceReport, 
                queue => queue.QueueName = "GenerateCarServiceReports");
        });
    }
}
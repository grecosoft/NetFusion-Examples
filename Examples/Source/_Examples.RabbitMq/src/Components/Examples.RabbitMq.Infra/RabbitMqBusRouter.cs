using EasyNetQ.Topology;
using Examples.RabbitMq.App.Handlers;
using Examples.RabbitMq.Domain.Commands;
using Examples.RabbitMq.Domain.Entities;
using Examples.RabbitMq.Domain.Events;
using NetFusion.Common.Base;
using NetFusion.Integration.RabbitMQ;

namespace Examples.RabbitMq.Infra;

public class RabbitMqBusRouter : RabbitMqRouter
{
    public RabbitMqBusRouter() : base("testBus")
    {
    }

    protected override void OnDefineEntities()
    {
        // -- Microservice 1:
        
        DefineExchange<PropertySold>(meta =>
        {
            meta.ExchangeName = "RealEstate";
            meta.ExchangeType = ExchangeType.Direct;
            meta.WhenDomainEvent(m => m.State != "WV");
        });
        
        DefineExchange<AutoSaleCompleted>(meta =>
        {
            meta.ExchangeName = "CompletedAutoSales";
            meta.ExchangeType = ExchangeType.Topic;
            meta.AlternateExchangeName = "NonRouted_CompletedAutoSales";
            meta.WhenDomainEvent(m => m.Make != "Yugo");
            meta.RouteKey( m => $"{m.Make}.{m.Model}.{m.Year}");
        });
        
        DefineQueue<SendEmail>(route =>
        {
            route.ToConsumer<EmailHandler>(c => c.GenerateEmail, meta =>
            {
                meta.QueueName = "GenerateAndSendEmail";
            });
        });
        
        DefineQueueWithResponse<GenerateCarFax, CarFaxSummary>(route =>
        {
            route.ToConsumer<CarFaxHandler>(c => c.GenerateCarFax, meta => meta.QueueName = "GenerateCarFax");
        });

        DefineRpcQueue("TaxCalculations", meta => { meta.PrefetchCount = 5; });
        
        DefineRpcQueueRoute<CalculateAutoTax, TaxCalc>("TaxCalculations", route =>
        {
            route.ToConsumer<TaxCalculationHandler>(c => c.CalculateAutoTax);
        });
        
        DefineRpcQueueRoute<CalculatePropertyTax, TaxCalc>("TaxCalculations", route =>
        {
            route.ToConsumer<TaxCalculationHandler>(c => c.CalculatePropertyTax);
        });
        
        
        // -- Microservice 2:
        
        SubscribeToExchange<PropertySold>("RealEstate", 
            new[] {"CT", "NY", "NH", "MA" },
            route =>
            {
                route.ToConsumer<RealEstateHandler>(c => c.NorthEast,
                    meta =>
                    {
                        meta.QueueName = "NorthEast";
                    });
            });
        
        SubscribeToExchange<PropertySold>("RealEstate",
            new[] {"NC", "SC", "FL" },
            route =>
            {
                route.ToConsumer<RealEstateHandler>(c => c.NorthEast,
                    meta =>
                    {
                        meta.QueueName = "SouthEast";
                    });
            });
        
        SubscribeToExchange<AutoSaleCompleted>("CompletedAutoSales",
            new[] {"VW.*.2017", "BMW.*.2018" },
            route =>
            {
                route.ToConsumer<AutoSalesHandler>(c => c.GermanAutoSales,
                    meta =>
                    {
                        meta.QueueName = "GermanAutosSales";
                    });
            });
        
        SubscribeToExchange<AutoSaleCompleted>("CompletedAutoSales",
            new[] {"Chevy.*.2017", "Buick.*.2019" },
            route =>
            {
                route.ToConsumer<AutoSalesHandler>(c => c.AmericanAutoSales,
                    meta =>
                    {
                        meta.QueueName = "AmericanAutosSales";
                    });
            });
        
        RouteToQueue<SendEmail>("GenerateAndSendEmail", options =>
        {
            options.ContentType = ContentTypes.MessagePack;
        });
        
        RouteToQueueWithResponse<GenerateCarFax, CarFaxSummary>("GenerateCarFax", 
            route => route.ToConsumer<CarFaxHandler>(c => c.ReportGenerated, 
                meta => meta.QueueName = "GeneratedCarFaxSummaries"));
        
        RouteToRpcQueue<CalculateAutoTax>("TaxCalculations");
        RouteToRpcQueue<CalculatePropertyTax>("TaxCalculations");
    }
}
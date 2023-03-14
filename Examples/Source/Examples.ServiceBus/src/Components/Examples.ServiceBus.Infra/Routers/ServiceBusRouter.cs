using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Administration;
using Examples.ServiceBus.App.Handlers;
using Examples.ServiceBus.Domain.Commands;
using Examples.ServiceBus.Domain.Events;
using NetFusion.Integration.ServiceBus;

namespace Examples.ServiceBus.Infra.Routers;

public class ServiceBusRouter : NamespaceRouter
{
    public ServiceBusRouter() : base("netfusionBus")
    {
    }

    protected override void OnDefineEntities()
    {
        // Publishing Microservice
        // ----------------------------------
        RouteToQueue<SendEmail>("ProcessEmails");
        
        RouteToQueueWithResponse<GenerateCarFaxReport, CarFaxReport>("GenerateCarFaxReports", route => {
            route.ToConsumer<CarFaxReportHandler>(c => c.ReportGenerated, queue =>
            {
                queue.QueueName = "CompletedCarFaxReports";
            });
        });
        
        RouteToQueueWithResponse<GenerateServiceReport, ServiceReport>("GenerateCarServiceReports",
            route => route.ToConsumer<ServiceReportHandler>(
                c => c.OnServiceReportReceived, 
                queue => queue.QueueName = "FinishedServiceReports") );
        
        RouteToRpcQueue<CalculateAutoTax>("TaxCalculations");
        RouteToRpcQueue<CalculatePropertyTax>("TaxCalculations");
        
        DefineTopic<PropertySold>(topic =>
        {
            topic.TopicName = "RealEstate";
            topic.WhenDomainEvent(e => e.Zip != "15068");
        });

        DefineTopic<AutoSaleCompleted>(topic =>
        {
            topic.TopicName = "CompletedAutoSales";
            topic.SetMessageProperties((m, e) => m.ApplicationProperties["Make"] = e.Make);
        });
        
        // Subscribing Microservice
        // ----------------------------------
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
        
        DefineRpcQueue("TaxCalculations");
        
        DefineRpcQueueRoute<CalculateAutoTax, TaxCalc>("TaxCalculations", route =>
        {
            route.ToConsumer<TaxCalculationHandler>(c => c.CalculateAutoTax);
        });

        DefineRpcQueueRoute<CalculatePropertyTax, TaxCalc>("TaxCalculations", route =>
        {
            route.ToConsumer<TaxCalculationHandler>(c => c.CalculatePropertyTax);
        });
        
        SubscribeToTopic<PropertySold>("RealEstate", route =>
        {
            route.ToConsumer<RealEstateHandler>(c => c.OnPropertySold, meta =>
            {
                meta.SubscriptionName = "SoldProperties";
            });
        });
        
        SubscribeToTopic<AutoSaleCompleted>("CompletedAutoSales", route =>
        {
            route.ToConsumer<AutoSalesHandler>(c => c.OnAmericanAutoSales, meta =>
            {
                meta.SubscriptionName = "AmericanSales";
                meta.AddRule("AmericanMakeFiler", new SqlRuleFilter("Make IN  ('Ford', 'Buick')"));
            });
        });
        
        SubscribeToTopic<AutoSaleCompleted>("CompletedAutoSales", route =>
        {
            route.ToConsumer<AutoSalesHandler>(c => c.OnGermanAutoSales, meta =>
            {
                meta.SubscriptionName = "GermanSales";
                meta.AddRule("GermanMakeFiler", new SqlRuleFilter("Make IN  ('VW', 'BMW')"));
            });
        });
    }
}
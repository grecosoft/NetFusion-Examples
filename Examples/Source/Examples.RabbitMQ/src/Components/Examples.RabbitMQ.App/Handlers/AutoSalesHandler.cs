using System;
using Examples.RabbitMQ.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class AutoSalesHandler
{
    public void OnGermanAutoSales(AutoSaleCompleted completedSale)
    {
        Console.WriteLine(nameof(OnGermanAutoSales));
        Console.WriteLine(completedSale.ToIndentedJson());
    }
    
    public void OnAmericanAutoSales(AutoSaleCompleted completedSale)
    {
        Console.WriteLine(nameof(OnAmericanAutoSales));
        Console.WriteLine(completedSale.ToIndentedJson());
    }
}
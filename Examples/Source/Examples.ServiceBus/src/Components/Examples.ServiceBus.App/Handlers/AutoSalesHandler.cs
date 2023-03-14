using System;
using Examples.ServiceBus.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

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
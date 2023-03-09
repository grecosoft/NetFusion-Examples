using System;
using Examples.RabbitMq.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMq.App.Handlers;

public class AutoSalesHandler
{
    public void GermanAutoSales(AutoSaleCompleted completedSale)
    {
        Console.WriteLine(completedSale.ToIndentedJson());
    }
    
    public void AmericanAutoSales(AutoSaleCompleted completedSale)
    {
        Console.WriteLine(completedSale.ToIndentedJson());
    }
}
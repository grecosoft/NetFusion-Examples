using System;
using Examples.RabbitMq.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMq.App.Handlers;

public class RealEstateHandler
{
    public void NorthEast(PropertySold propertySold)
    {
        Console.WriteLine(propertySold.ToIndentedJson());
    }
    
    public void SouthEast(PropertySold propertySold)
    {
        Console.WriteLine(propertySold.ToIndentedJson());
    }
}
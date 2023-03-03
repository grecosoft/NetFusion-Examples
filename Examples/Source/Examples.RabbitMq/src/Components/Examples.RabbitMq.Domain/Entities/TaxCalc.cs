using System;

namespace Examples.RabbitMq.Domain.Entities;

public class TaxCalc
{
    public decimal Amount { get; set; }
    public DateTime DateCalculated { get; set; }
}
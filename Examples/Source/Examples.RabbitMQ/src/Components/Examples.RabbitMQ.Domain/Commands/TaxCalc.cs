using System;

namespace Examples.RabbitMQ.Domain.Commands;

public class TaxCalc
{
    public decimal Amount { get; }
    public DateTime DateCalculated { get; }

    public TaxCalc(decimal amount, DateTime dateCalculated)
    {
        Amount = amount;
        DateCalculated = dateCalculated;
    }
}
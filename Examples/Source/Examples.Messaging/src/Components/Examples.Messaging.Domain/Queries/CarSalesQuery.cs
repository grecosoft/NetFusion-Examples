using Examples.Messaging.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.Messaging.Domain.Queries;

public class CarSalesQuery : Query<Car[]>
{
    public string Make { get; }
    public int Year { get; }

    public CarSalesQuery(
        string make,
        int year)
    {
        Make = make;
        Year = year;
    }
}
using Demo.Domain.Queries;
using Microsoft.Extensions.Logging;
using NetFusion.Messaging;

namespace Demo.App.Handlers
{
    public class TimestampHandler : IQueryConsumer
    {
        private readonly ILogger _logger;
        
        public TimestampHandler(ILogger<TimestampHandler> logger)
        {
            _logger = logger;
        }
        
        [InProcessHandler]
        public SensorReading When(QuerySensorData query)
        {
            _logger.LogDebug($"Query Time: {query.CurrentDate}");

            return new SensorReading
            {
                MinValue = 10,
                MaxValue = 130
            };
        }
    }
}

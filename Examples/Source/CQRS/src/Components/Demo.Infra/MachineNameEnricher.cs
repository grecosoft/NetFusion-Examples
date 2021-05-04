using System;
using System.Threading.Tasks;
using NetFusion.Messaging.Enrichers;
using NetFusion.Messaging.Types.Attributes;
using NetFusion.Messaging.Types.Contracts;

namespace Demo.Infra
{
    public class MachineNameEnricher : IMessageEnricher
    {
        public Task EnrichAsync(IMessage message)
        {
            message.Attributes.SetStringValue("MachineName", Environment.MachineName);
            return Task.CompletedTask;
        }
    }
}

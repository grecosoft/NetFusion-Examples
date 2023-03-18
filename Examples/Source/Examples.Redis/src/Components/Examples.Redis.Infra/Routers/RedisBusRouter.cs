using Examples.Redis.App.Handlers;
using Examples.Redis.Domain.Events;
using NetFusion.Integration.Redis;

namespace Examples.Redis.Infra.Routers;

public class RedisBusRouter : RedisRouter
{
    public RedisBusRouter() : base("testDb")
    {
    }

    protected override void OnDefineEntities()
    {
        DefineChannel<LogEntryCreated> (channel =>
        {
            channel.ChannelName = "log-entries";
            channel.AppliesWhen(log => 2 < log.Severity);
            channel.SetEventData(log => $"{log.LogLevel}.{log.Severity}");
        });
        
        SubscribeToChannel<LogEntryCreated>("log-entries.*.3", route =>
        {
            route.ToConsumer<LogEntryHandler>(c => c.OnLogCreated);
        });
    }
}
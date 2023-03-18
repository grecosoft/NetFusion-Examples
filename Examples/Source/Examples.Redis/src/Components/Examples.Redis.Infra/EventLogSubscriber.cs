using System;
using System.Threading.Tasks;
using Examples.Redis.App.Services;
using Examples.Redis.Domain.Events;
using NetFusion.Common.Extensions;
using NetFusion.Integration.Redis;

namespace Examples.Redis.Infra;

public class EventLogSubscriber : IEventLogSubscriber
{
    private readonly ISubscriptionService _subscription;
    
    public EventLogSubscriber(
        ISubscriptionService subscription)
    {
        _subscription = subscription;
    }

    public void Subscribe(string channel)
    {
        _subscription.Subscribe<LogEntryCreated>("testDb", channel, OnEventLog);
    }

    public void UnSubscribe(string channel)
    {
        _subscription.UnSubscribe("testDb", channel);
    }

    private void OnEventLog(LogEntryCreated domainEvent)
    {
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
using Examples.Redis.App.Services;
using Examples.Redis.Domain.Events;
using Examples.Redis.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Integration.Redis;
using NetFusion.Messaging;
using StackExchange.Redis;

namespace Examples.Redis.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly IDatabase _redisDb;
    private readonly IMessagingService _messaging;
    private readonly IEventLogSubscriber _eventLogSubscriber;
    
    public ExamplesController(
        IRedisService redis,
        IMessagingService messaging,
        IEventLogSubscriber eventLogSubscriber)
    {
        _redisDb = redis.GetDatabase("testDb");
        _messaging = messaging;
        _eventLogSubscriber = eventLogSubscriber;
    }

    [HttpPost("set/add/{key}/{value}")]
    public async Task<IActionResult> SetAdd(string key, string value)
    {
        Console.WriteLine($"Database Number: {_redisDb.Database}");
        await _redisDb.SetAddAsync(key, value);
        return Ok();
    }

    [HttpPost("set/pop/{key}")]
    public async Task<IActionResult> SetPop(string key)
    {
        var value = await _redisDb.SetPopAsync(key);
        return Ok(value.ToString());
    }

    [HttpGet("set/members/{key}")]
    public async Task<IActionResult> SetMembers(string key)
    {
        var values = await _redisDb.SetMembersAsync(key);
        return Ok(values.Select(v => v.ToString()));
    }

    [HttpPost("log/entries")]
    public async Task<IActionResult> PublishLogEntry([FromBody]LogEntryModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var domainEvent = new LogEntryCreated(model.LogLevel, model.Severity) { Message = model.Message };
        await _messaging.PublishAsync(domainEvent);

        return Ok();
    }

    [HttpPost("log/entries/subscribe/{channel}")]
    public IActionResult SubscribeToLog(string channel)
    {
        _eventLogSubscriber.Subscribe(channel);
        return Ok();
    }

    [HttpDelete("log/entries/subscribe/{channel}")]
    public IActionResult UnSubscribeFromLog(string channel)
    {
        _eventLogSubscriber.UnSubscribe(channel);
        return Ok();
    }
}
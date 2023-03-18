namespace Examples.Redis.App.Services;

public interface IEventLogSubscriber
{
    void Subscribe(string channel);
    void UnSubscribe(string channel);
}
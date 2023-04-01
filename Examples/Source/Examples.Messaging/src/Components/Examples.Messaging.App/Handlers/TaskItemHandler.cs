using System;
using System.Threading.Tasks;
using Examples.Messaging.Domain.Commands;
using Examples.Messaging.Domain.Events;
using NetFusion.Messaging;

namespace Examples.Messaging.App.Handlers;

public class TaskItemHandler
{
    private readonly IMessagingService _messaging;

    public TaskItemHandler(IMessagingService messaging)
    {
        _messaging = messaging;
    }
    
    public async Task<string> CreateTask(AddTaskItemCommand command)
    {
        var taskId = Guid.NewGuid().ToString();

        var domainEvt = new ImportantTaskCreated(taskId, command.Name, command.DateDue,
            command.DateDue.Subtract(DateTime.Now).Days);

        await _messaging.PublishAsync(domainEvt);

        return taskId;
    }
}
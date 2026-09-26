using AsanNobat.Domain.Events;
using Microsoft.Extensions.Logging;

namespace AsanNobat.Application.TodoItems.EventHandlers;

public class LogTodoItemCompleted : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<LogTodoItemCompleted> _logger;

    public LogTodoItemCompleted(ILogger<LogTodoItemCompleted> logger)
    {
        _logger = logger;
    }

    public ValueTask Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AsanNobat Domain Event: {DomainEvent}", notification.GetType().Name);

        return ValueTask.CompletedTask;
    }
}

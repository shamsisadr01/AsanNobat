using AsanNobat.Domain.BusinessAgg.Events;
using Microsoft.Extensions.Logging;

namespace AsanNobat.Application.BusinessAgg.EventHandlers;

public class LogBusinessDeleted : INotificationHandler<BusinessDeletedEvent>
{
    private readonly ILogger<LogBusinessDeleted> _logger;

    public LogBusinessDeleted(ILogger<LogBusinessDeleted> logger)
    {
        _logger = logger;
    }

    public ValueTask Handle(BusinessDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AsanNobat Domain Event: {DomainEvent} - BusinessId: {BusinessId}",
            notification.GetType().Name, notification.Business.Id);
        return ValueTask.CompletedTask;
    }
}

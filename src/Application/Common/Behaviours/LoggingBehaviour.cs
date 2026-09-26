using Microsoft.Extensions.Logging;

namespace AsanNobat.Application.Common.Behaviours;

public sealed class LoggingBehaviour<TMessage, TResponse> : MessagePreProcessor<TMessage, TResponse>
    where TMessage : notnull, IMessage
{
    private readonly ILogger _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public LoggingBehaviour(ILogger<TMessage> logger, IUser user, IIdentityService identityService)
    {
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }

    protected override async ValueTask Handle(TMessage message, CancellationToken cancellationToken)
    {
        var requestName = typeof(TMessage).Name;
        var userId = _user.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = await _identityService.GetUserNameAsync(userId);
        }

        _logger.LogInformation("AsanNobat Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, message);
    }
}

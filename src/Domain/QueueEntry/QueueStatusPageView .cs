namespace AsanNobat.Domain.QueueEntry;

public class QueueStatusPageView : BaseEntity
{

    public string TicketId { get; set; } = string.Empty;
    public int? PositionNumber { get; set; }
    public string StatusMessage { get; set; } = string.Empty;
    public int? EstimatedWaitMinutes { get; set; }
    public QueueEntryStatus Status { get; set; }
    public QueueProgressStep ProgressStep { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string MaskedPhoneNumber { get; set; } = string.Empty;
    public bool CanLeaveQueue { get; set; }
    public bool UsesWebSocket { get; set; }
    public int PollingFallbackIntervalSeconds { get; set; }


    public QueueStatusPageView()
    {
    }

    private QueueStatusPageView(string ticketId, int? positionNumber, string statusMessage, int? estimatedWaitMinutes,
        QueueEntryStatus status, QueueProgressStep progressStep, string customerName, string maskedPhoneNumber,
        bool canLeaveQueue, bool usesWebSocket, int pollingFallbackIntervalSeconds)
    {
        TicketId = ticketId;
        PositionNumber = positionNumber;
        StatusMessage = statusMessage;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        Status = status;
        ProgressStep = progressStep;
        CustomerName = customerName;
        MaskedPhoneNumber = maskedPhoneNumber;
        CanLeaveQueue = canLeaveQueue;
        UsesWebSocket = usesWebSocket;
        PollingFallbackIntervalSeconds = pollingFallbackIntervalSeconds;
    }

    public static QueueStatusPageView Create(string ticketId, int? positionNumber, string statusMessage, int? estimatedWaitMinutes,
        QueueEntryStatus status, QueueProgressStep progressStep, string customerName, string maskedPhoneNumber,
        bool canLeaveQueue, bool usesWebSocket, int pollingFallbackIntervalSeconds)
        => new(ticketId, positionNumber, statusMessage, estimatedWaitMinutes, status, progressStep, customerName, maskedPhoneNumber,
            canLeaveQueue, usesWebSocket, pollingFallbackIntervalSeconds);

    public void Update(string ticketId, int? positionNumber, string statusMessage, int? estimatedWaitMinutes,
        QueueEntryStatus status, QueueProgressStep progressStep, string customerName, string maskedPhoneNumber,
        bool canLeaveQueue, bool usesWebSocket, int pollingFallbackIntervalSeconds)
    {
        TicketId = ticketId;
        PositionNumber = positionNumber;
        StatusMessage = statusMessage;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        Status = status;
        ProgressStep = progressStep;
        CustomerName = customerName;
        MaskedPhoneNumber = maskedPhoneNumber;
        CanLeaveQueue = canLeaveQueue;
        UsesWebSocket = usesWebSocket;
        PollingFallbackIntervalSeconds = pollingFallbackIntervalSeconds;

    }

    public void Delete()
    {

    }
}

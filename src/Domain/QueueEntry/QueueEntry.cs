using AsanNobat.Domain.BusinessAgg;

namespace AsanNobat.Domain.QueueEntry;

public class QueueEntry : Aggregate
{  

    public string Titile { get; set; } = string.Empty;
    public Guid BusinessId { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? CounterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PartySize { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public EntrySource Source { get; set; }
    public QueueEntryStatus Status { get; set; }
    public bool SmsConsentGranted { get; set; }
    public DateTimeOffset JoinedAtUtc { get; set; }
    public DateTimeOffset? CalledAtUtc { get; set; }
    public DateTimeOffset? ServedAtUtc { get; set; }
    public int? PositionInQueue { get; set; }
    public int? EstimatedWaitMinutes { get; set; }
    public Guid? BookingId { get; set; }
    public string MaskedPhoneNumber { get; set; } = string.Empty;

    public QueueEntry()
    {
    }

    private QueueEntry(string titile, Guid businessId, Guid? serviceId, Guid? counterId, string name, int partySize,
      string phoneNumber, string notes, EntrySource source, QueueEntryStatus status, bool smsConsentGranted,
      DateTimeOffset joinedAtUtc, int? positionInQueue, int? estimatedWaitMinutes,
      Guid? bookingId, string maskedPhoneNumber)
    {
        Titile = titile;
        BusinessId = businessId;
        ServiceId = serviceId;
        CounterId = counterId;
        Name = name;
        PartySize = partySize;
        PhoneNumber = phoneNumber;
        Notes = notes;
        Source = source;
        Status = status;
        SmsConsentGranted = smsConsentGranted;
        JoinedAtUtc = joinedAtUtc;
        PositionInQueue = positionInQueue;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        BookingId = bookingId;
        MaskedPhoneNumber = maskedPhoneNumber;
    }

   

    public static QueueEntry Create(string titile, Guid businessId, Guid? serviceId, Guid? counterId, string name, int partySize,
      string phoneNumber, string notes, EntrySource source, QueueEntryStatus status, bool smsConsentGranted,
      DateTimeOffset joinedAtUtc, int? positionInQueue, int? estimatedWaitMinutes,
      Guid? bookingId, string maskedPhoneNumber) => new(titile,businessId,serviceId,counterId,name,partySize,
                                                     phoneNumber,notes,source, status, smsConsentGranted,DateTimeOffset.Now,positionInQueue,
                                                     estimatedWaitMinutes,bookingId,maskedPhoneNumber);

    public void Update(DateTimeOffset? calledAtUtc, DateTimeOffset? servedAtUtc, int? positionInQueue,
       int? estimatedWaitMinutes, Guid? bookingId)
    {
        CalledAtUtc = calledAtUtc;
        ServedAtUtc = servedAtUtc;
        PositionInQueue = positionInQueue;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        PositionInQueue = positionInQueue;
        //AddDomainEvent();
    }

    public void Delete()
    {
        //AddDomainEvent();
    }

    
}



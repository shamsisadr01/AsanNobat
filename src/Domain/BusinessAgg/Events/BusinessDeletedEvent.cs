using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Events;

/// <summary>
/// رخداد حذف کسب‌وکار؛ پس از حذف اگریگیت Business منتشر می‌شود.
/// </summary>
public class BusinessDeletedEvent : BaseEvent
{
    public BusinessDeletedEvent(Business business)
    {
        Business = business;
    }

    public Business Business { get; }
}

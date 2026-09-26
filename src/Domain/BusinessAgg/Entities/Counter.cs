using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Counter : BaseEntity
{
    public string Name { get; private set; } = null!;
    public bool IsActive { get; private set; }

    /// <summary>
    /// شناسه ورودی صفی که در حال حاضر در این باجه در حال سرویس است.
    /// در صورت آزاد بودن باجه، مقدار آن خالی است.
    /// </summary>
    public int? CurrentServingQueueEntryId { get; private set; }

    /// <summary>
    /// مشخص می‌کند که آیا باجه در حال ارائه خدمت است یا خیر.
    /// </summary>
    public bool IsServing => CurrentServingQueueEntryId.HasValue;


    /// <summary>
    /// شناسه خدماتی که این باجه می‌تواند ارائه دهد.
    /// لیست خالی به معنی پوشش تمام خدمات است.
    /// </summary>
    private readonly List<Service> _assignedServices = [];

    public IReadOnlyCollection<Service> AssignedServices =>
        _assignedServices.AsReadOnly();

    private Counter()
    {
        
    }

    internal Counter(string name, bool isActive, int? currentServingQueueEntryId = null)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        Name = name;
        IsActive = isActive;
        CurrentServingQueueEntryId = currentServingQueueEntryId;
    }

    public void Update(string name, bool isActive, int? currentServingQueueEntryId = null)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        Name = name;
        IsActive = isActive;
        CurrentServingQueueEntryId = currentServingQueueEntryId;
    }


    public void AddService(Service service)
    {
        _assignedServices.Add(service);
    }

    public void RemoveService(Service service)
    {
        _assignedServices.Remove(service);
    }
}

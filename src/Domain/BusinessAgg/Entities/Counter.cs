using System;
using System.Collections.Generic;
using System.Text;
using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Counter : BaseEntity
{
    public string Name { get; private set; } = null!;
    public bool IsActive { get; private set; }

    /// <summary>
    /// وضعیت فعلی باجه؛ آزاد یا مشغول به ارائه خدمت.
    /// </summary>
    public CounterStatus Status { get; private set; }

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
    public List<int> AssignedServiceIds { get; private set; } = [];
}

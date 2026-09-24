using System;
using System.Collections.Generic;
using System.Text;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Provider : BaseEntity
{
    public int BusinessId { get; private set; }

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    /// <summary>
    /// شناسه خدماتی که این ارائه‌دهنده ارائه می‌کند.
    /// </summary>
    public List<int> ServiceIds { get; private set; } = [];
}

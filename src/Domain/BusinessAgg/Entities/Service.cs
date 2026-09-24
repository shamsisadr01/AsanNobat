using System;
using System.Collections.Generic;
using System.Text;
using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Service : BaseEntity
{
    public string Name { get; private set; } = null!; 
    public string? Description { get; private set; }

    /// <summary>
    /// میانگین زمان ارائه این خدمت بر حسب دقیقه.
    /// </summary>
    public int AverageServiceTimeMinutes { get; private set; }
    public bool IsActive { get; private set; }
    public string? LogoUrl { get; private set; }
    public ServiceMode Mode { get; private set; }
}

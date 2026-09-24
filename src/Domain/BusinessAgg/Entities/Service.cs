using AsanNobat.Domain.BusinessAgg.Enums;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Service : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }

    /// <summary>
    /// میانگین زمان ارائه این خدمت بر حسب دقیقه.
    /// </summary>
    public int AverageServiceTimeMinutes { get; private set; }
    public bool IsActive { get; private set; } = false;
    public string? LogoUrl { get; private set; }
    public ServiceMode Mode { get; private set; }


    internal Service(string name, string? description, bool isActive, string? logoUrl, ServiceMode mode = ServiceMode.Both, int averageServiceTimeMinutes = 2)
    {
        Guard(name, averageServiceTimeMinutes);

        Name = name;
        Description = description;
        AverageServiceTimeMinutes = averageServiceTimeMinutes;
        IsActive = isActive;
        LogoUrl = logoUrl;
        Mode = mode;
    }

    public void Update(string name, string? description, bool isActive, string? logoUrl, ServiceMode mode,int averageServiceTimeMinutes)
    {
        Guard(name, averageServiceTimeMinutes);
        Name = name;
        Description = description;
        AverageServiceTimeMinutes = averageServiceTimeMinutes;
        IsActive = isActive;
        LogoUrl = logoUrl;
        Mode = mode;
    }

    public void Guard(string name, int averageServiceTimeMinutes)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(averageServiceTimeMinutes);
    }
}

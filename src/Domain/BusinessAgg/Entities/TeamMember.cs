using AsanNobat.Domain.BusinessAgg.Enums;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class TeamMember : BaseEntity
{
    public int BusinessId { get; private set; }

    public string Name { get; private set; } = null!;

    /// <summary>
    /// هش پین عضو؛ مقدار اصلی پین هرگز ذخیره نمی‌شود.
    /// </summary>
    public string PinHash { get; private set; } = null!;

    /// <summary>
    /// ایمیل عضو در صورت استفاده از دعوت ایمیلی.
    /// </summary>
    public string Email { get; private set; } = null!;

    /// <summary>
    /// نقش عضو در کسب‌وکار.
    /// </summary>
    public TeamRole Role { get; private set; }

    /// <summary>
    /// زمان ایجاد یا دعوت عضو به صورت UTC.
    /// </summary>
    public DateTime CreatedAtUtc { get; private set; }


    private TeamMember()
    {
    }

    internal TeamMember(int businessId,string name,string pinHash,string email,TeamRole role)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            businessId,
            nameof(businessId));

        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentException.ThrowIfNullOrEmpty(pinHash, nameof(pinHash));
        ArgumentException.ThrowIfNullOrEmpty(email, nameof(email));

        BusinessId = businessId;
        Name = name;
        PinHash = pinHash;
        Email = email;
        Role = role;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Update(string name, string email,TeamRole role)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentException.ThrowIfNullOrEmpty(email, nameof(email));

        Name = name;
        Email = email;
        Role = role;
    }

    public void UpdatePin(string pinHash)
    {
        ArgumentException.ThrowIfNullOrEmpty(pinHash, nameof(pinHash));

        PinHash = pinHash;
    }

}

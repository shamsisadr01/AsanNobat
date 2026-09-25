using System;
using System.Collections.Generic;
using System.Text;
using AsanNobat.Domain.BusinessAgg.Enums;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class TeamMember : BaseEntity
{
    public int BusinessId { get; private set; }

    public string Name { get; private set; } = null!;

    /// <summary>
    /// روش احراز هویت عضو؛ پین سریع یا دعوت ایمیلی.
    /// </summary>
    public StaffAuthType AuthType { get; private set; }

    /// <summary>
    /// هش پین عضو؛ مقدار اصلی پین هرگز ذخیره نمی‌شود.
    /// </summary>
    public string? PinHash { get; private set; }

    /// <summary>
    /// ایمیل عضو در صورت استفاده از دعوت ایمیلی.
    /// </summary>
    public string? Email { get; private set; }

    /// <summary>
    /// نقش عضو در کسب‌وکار.
    /// </summary>
    public TeamRole Role { get; private set; }

    /// <summary>
    /// زمان ایجاد یا دعوت عضو به صورت UTC.
    /// </summary>
    public DateTime CreatedAtUtc { get; private set; }


}

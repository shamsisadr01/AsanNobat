namespace AsanNobat.Domain.BusinessAgg.Enums;

/// <summary>
/// نقش عضو در کسب‌وکار.
/// </summary>
public enum TeamRole
{
    /// <summary>
    /// مالک کسب‌وکار با دسترسی کامل.
    /// </summary>
    Owner = 1,

    /// <summary>
    /// مدیر کسب‌وکار با دسترسی مدیریتی.
    /// </summary>
    Manager = 2,

    /// <summary>
    /// کارمند با دسترسی‌های عملیاتی.
    /// </summary>
    Staff = 3
}

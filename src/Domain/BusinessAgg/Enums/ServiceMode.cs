using System;
using System.Collections.Generic;
using System.Text;

namespace AsanNobat.Domain.BusinessAgg.Enums;

/// <summary>
/// نحوه دریافت خدمت.
/// </summary>
public enum ServiceMode
{
    /// <summary>
    /// فقط مراجعه حضوری و بدون رزرو قبلی.
    /// </summary>
    WalkInOnly = 1,

    /// <summary>
    /// فقط با رزرو قبلی.
    /// </summary>
    BookingOnly = 2,

    /// <summary>
    /// امکان دریافت خدمت هم به‌صورت حضوری و هم با رزرو قبلی.
    /// </summary>
    Both = 3
}

using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Application.BusinessAgg.Queries.Common;

public class ServiceDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    /// <summary>
    /// میانگین زمان ارائه این خدمت بر حسب دقیقه.
    /// </summary>
    public int AverageServiceTimeMinutes { get; init; }

    public bool IsActive { get; init; }

    public string? LogoUrl { get; init; }

    public ServiceMode Mode { get; init; }
}

public class ProviderDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; }

    /// <summary>
    /// خدماتی که به این تامین‌کننده متصل شده‌اند.
    /// </summary>
    public IReadOnlyCollection<ServiceDto> Services { get; init; } = [];
}

public class CounterDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; }

    /// <summary>
    /// مشخص می‌کند که آیا باجه در حال ارائه خدمت است یا خیر.
    /// </summary>
    public bool IsServing { get; init; }

    /// <summary>
    /// خدماتی که این باجه می‌تواند ارائه دهد؛ لیست خالی به معنی پوشش تمام خدمات است.
    /// </summary>
    public IReadOnlyCollection<ServiceDto> AssignedServices { get; init; } = [];
}

public class TeamMemberDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public TeamRole Role { get; init; }

    public DateTime CreatedAtUtc { get; init; }
}

public class BusinessChildDtoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AsanNobat.Domain.BusinessAgg.Entities.Service, ServiceDto>();
        config.NewConfig<AsanNobat.Domain.BusinessAgg.Entities.Provider, ProviderDto>();
        config.NewConfig<AsanNobat.Domain.BusinessAgg.Entities.Counter, CounterDto>();
        config.NewConfig<AsanNobat.Domain.BusinessAgg.Entities.TeamMember, TeamMemberDto>();
    }
}

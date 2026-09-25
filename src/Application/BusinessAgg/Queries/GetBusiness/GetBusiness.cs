using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Domain.BusinessAgg.Enums;
using AutoMapper;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusiness;

[Authorize]
public record GetBusinessQuery(int Id) : IRequest<BusinessDetailsDto>;

public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, BusinessDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BusinessDetailsDto> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .ProjectTo<BusinessDetailsDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, business);

        return business;
    }
}

public class BusinessDetailsDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string UrlSlug { get; init; } = string.Empty;

    public string? Description { get; init; }

    public string PhoneNumber { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;

    public IReadOnlyCollection<ServiceDto> Services { get; init; } = [];

    public IReadOnlyCollection<ProviderDto> Providers { get; init; } = [];

    public IReadOnlyCollection<CounterDto> Counters { get; init; } = [];

    public IReadOnlyCollection<TeamMemberDto> TeamMembers { get; init; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AsanNobat.Domain.BusinessAgg.Business, BusinessDetailsDto>();
            CreateMap<AsanNobat.Domain.BusinessAgg.Entities.Service, ServiceDto>();
            CreateMap<AsanNobat.Domain.BusinessAgg.Entities.Provider, ProviderDto>();
            CreateMap<AsanNobat.Domain.BusinessAgg.Entities.Counter, CounterDto>();
            CreateMap<AsanNobat.Domain.BusinessAgg.Entities.TeamMember, TeamMemberDto>();
        }
    }
}

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

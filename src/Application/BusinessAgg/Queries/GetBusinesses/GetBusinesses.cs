using AutoMapper;
using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusinesses;

[Authorize]
public record GetBusinessesQuery : IRequest<BusinessesVm>;

public class GetBusinessesQueryHandler : IRequestHandler<GetBusinessesQuery, BusinessesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BusinessesVm> Handle(GetBusinessesQuery request, CancellationToken cancellationToken)
    {
        return new BusinessesVm
        {
            Businesses = await _context.Businesses
                .AsNoTracking()
                .ProjectTo<BusinessDto>(_mapper.ConfigurationProvider)
                .OrderBy(b => b.Name)
                .ToListAsync(cancellationToken)
        };
    }
}

public class BusinessesVm
{
    public IReadOnlyCollection<BusinessDto> Businesses { get; init; } = [];
}

public class BusinessDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string UrlSlug { get; init; } = string.Empty;

    public string? Description { get; init; }

    public string PhoneNumber { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AsanNobat.Domain.BusinessAgg.Business, BusinessDto>();
        }
    }
}

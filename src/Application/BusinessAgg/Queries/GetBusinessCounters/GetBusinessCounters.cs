using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.GetBusiness;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusinessCounters;

[Authorize]
public record GetBusinessCountersQuery(int BusinessId) : IRequest<CountersVm>;

public class GetBusinessCountersQueryHandler : IRequestHandler<GetBusinessCountersQuery, CountersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessCountersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CountersVm> Handle(GetBusinessCountersQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectTo<CountersVm>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class CountersVm
{
    public IReadOnlyCollection<CounterDto> Counters { get; init; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AsanNobat.Domain.BusinessAgg.Business, CountersVm>()
                .ForMember(d => d.Counters, opt => opt.MapFrom(s => s.Counters));
        }
    }
}

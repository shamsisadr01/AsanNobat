using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.Common;

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

    public async ValueTask<CountersVm> Handle(GetBusinessCountersQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectToType<CountersVm>()
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class CountersVm
{
    public IReadOnlyCollection<CounterDto> Counters { get; init; } = [];

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AsanNobat.Domain.BusinessAgg.Business, CountersVm>()
                .Map(d => d.Counters, s => s.Counters);
        }
    }
}

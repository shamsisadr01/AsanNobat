using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.Common;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusinessProviders;

[Authorize]
public record GetBusinessProvidersQuery(int BusinessId) : IRequest<ProvidersVm>;

public class GetBusinessProvidersQueryHandler : IRequestHandler<GetBusinessProvidersQuery, ProvidersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessProvidersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async ValueTask<ProvidersVm> Handle(GetBusinessProvidersQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectToType<ProvidersVm>()
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class ProvidersVm
{
    public IReadOnlyCollection<ProviderDto> Providers { get; init; } = [];

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Business, ProvidersVm>()
                .Map(d => d.Providers, s => s.Providers);
        }
    }
}

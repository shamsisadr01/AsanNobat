using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.Common;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusinessServices;

[Authorize]
public record GetBusinessServicesQuery(int BusinessId) : IRequest<ServicesVm>;

public class GetBusinessServicesQueryHandler : IRequestHandler<GetBusinessServicesQuery, ServicesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessServicesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async ValueTask<ServicesVm> Handle(GetBusinessServicesQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectToType<ServicesVm>()
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class ServicesVm
{
    public IReadOnlyCollection<ServiceDto> Services { get; init; } = [];

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AsanNobat.Domain.BusinessAgg.Business, ServicesVm>()
                .Map(d => d.Services, s => s.Services);
        }
    }
}

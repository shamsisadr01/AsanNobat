using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.Common;

namespace AsanNobat.Application.BusinessAgg.Queries.GetBusinessTeamMembers;

[Authorize]
public record GetBusinessTeamMembersQuery(int BusinessId) : IRequest<TeamMembersVm>;

public class GetBusinessTeamMembersQueryHandler : IRequestHandler<GetBusinessTeamMembersQuery, TeamMembersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessTeamMembersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async ValueTask<TeamMembersVm> Handle(GetBusinessTeamMembersQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectToType<TeamMembersVm>()
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class TeamMembersVm
{
    public IReadOnlyCollection<TeamMemberDto> TeamMembers { get; init; } = [];

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AsanNobat.Domain.BusinessAgg.Business, TeamMembersVm>()
                .Map(d => d.TeamMembers, s => s.TeamMembers);
        }
    }
}

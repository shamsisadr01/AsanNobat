using AsanNobat.Application.Common.Interfaces;
using AsanNobat.Application.Common.Security;
using AsanNobat.Application.BusinessAgg.Queries.GetBusiness;

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

    public async Task<TeamMembersVm> Handle(GetBusinessTeamMembersQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .AsNoTracking()
            .Where(b => b.Id == request.BusinessId)
            .ProjectTo<TeamMembersVm>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        return business;
    }
}

public class TeamMembersVm
{
    public IReadOnlyCollection<TeamMemberDto> TeamMembers { get; init; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AsanNobat.Domain.BusinessAgg.Business, TeamMembersVm>()
                .ForMember(d => d.TeamMembers, opt => opt.MapFrom(s => s.TeamMembers));
        }
    }
}

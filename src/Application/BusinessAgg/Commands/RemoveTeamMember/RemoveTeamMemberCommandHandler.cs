namespace AsanNobat.Application.BusinessAgg.Commands.RemoveTeamMember;

public class RemoveTeamMemberCommandHandler : IRequestHandler<RemoveTeamMemberCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveTeamMemberCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Unit> Handle(RemoveTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveTeamMember(request.TeamMemberId);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

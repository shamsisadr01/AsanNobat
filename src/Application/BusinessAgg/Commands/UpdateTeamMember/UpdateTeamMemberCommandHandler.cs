namespace AsanNobat.Application.BusinessAgg.Commands.UpdateTeamMember;

public class UpdateTeamMemberCommandHandler : IRequestHandler<UpdateTeamMemberCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTeamMemberCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Unit> Handle(UpdateTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.UpdateTeamMember(request.TeamMemberId, request.Name, request.Email, request.Role);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

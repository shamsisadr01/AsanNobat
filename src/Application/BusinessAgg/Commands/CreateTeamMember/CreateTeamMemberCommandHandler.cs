namespace AsanNobat.Application.BusinessAgg.Commands.CreateTeamMember;

public class CreateTeamMemberCommandHandler : IRequestHandler<CreateTeamMemberCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTeamMemberCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<int> Handle(CreateTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        var teamMember = business.CreateTeamMember(
            request.Name,
            request.PinHash,
            request.Email,
            request.Role);

        await _context.SaveChangesAsync(cancellationToken);

        return teamMember.Id;
    }
}

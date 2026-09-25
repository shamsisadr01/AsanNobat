namespace AsanNobat.Application.BusinessAgg.Commands.RemoveBusiness;

public class RemoveBusinessCommandHandler : IRequestHandler<RemoveBusinessCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveBusinessCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, business);

        business.Remove();

        _context.Businesses.Remove(business);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

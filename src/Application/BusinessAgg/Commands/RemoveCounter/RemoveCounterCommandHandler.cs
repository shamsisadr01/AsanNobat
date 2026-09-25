namespace AsanNobat.Application.BusinessAgg.Commands.RemoveCounter;

public class RemoveCounterCommandHandler : IRequestHandler<RemoveCounterCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveCounterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCounterCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveCounter(request.CounterId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

namespace AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToCounter;

public class RemoveServiceToCounterCommandHandler : IRequestHandler<RemoveServiceToCounterCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveServiceToCounterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveServiceToCounterCommand request, CancellationToken cancellationTokens)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationTokens);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveServiceToCounter(request.ServiceId, request.CounterId);

        await _context.SaveChangesAsync(cancellationTokens);
    }
}

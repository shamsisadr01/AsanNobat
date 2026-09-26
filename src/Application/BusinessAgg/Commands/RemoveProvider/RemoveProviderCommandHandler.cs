namespace AsanNobat.Application.BusinessAgg.Commands.RemoveProvider;

public class RemoveProviderCommandHandler : IRequestHandler<RemoveProviderCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveProviderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Unit> Handle(RemoveProviderCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveProvider(request.ProviderId);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

namespace AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToProvider;

public class RemoveServiceToProviderCommandHandler : IRequestHandler<RemoveServiceToProviderCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveServiceToProviderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveServiceToProviderCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveServiceToProvider(request.ServiceId, request.ProviderId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

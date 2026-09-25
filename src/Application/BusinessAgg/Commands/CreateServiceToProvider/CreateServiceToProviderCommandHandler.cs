namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToProvider;

public class CreateServiceToProviderCommandHandler : IRequestHandler<CreateServiceToProviderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateServiceToProviderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateServiceToProviderCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.CreateServiceToProvider(request.ServiceId, request.ProviderId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

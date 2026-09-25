namespace AsanNobat.Application.BusinessAgg.Commands.CreateProvider;

public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProviderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        var provider = business.CreateProvider(request.Name, request.IsActive);

        await _context.SaveChangesAsync(cancellationToken);

        return provider.Id;
    }
}

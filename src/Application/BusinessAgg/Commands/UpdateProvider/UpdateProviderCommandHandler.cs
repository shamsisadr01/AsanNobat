namespace AsanNobat.Application.BusinessAgg.Commands.UpdateProvider;

public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProviderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.UpdateProvider(request.ProviderId, request.Name, request.IsActive);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

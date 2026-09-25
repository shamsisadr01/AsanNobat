namespace AsanNobat.Application.BusinessAgg.Commands.RemoveService;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveServiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.RemoveService(request.ServiceId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

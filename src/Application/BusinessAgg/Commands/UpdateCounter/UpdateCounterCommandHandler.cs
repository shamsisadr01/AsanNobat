namespace AsanNobat.Application.BusinessAgg.Commands.UpdateCounter;

public class UpdateCounterCommandHandler : IRequestHandler<UpdateCounterCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCounterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCounterCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.UpdateCounter(request.CounterId, request.Name, request.IsActive);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

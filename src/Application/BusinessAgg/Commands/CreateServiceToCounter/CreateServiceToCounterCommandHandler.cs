namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToCounter;

public class CreateServiceToCounterCommandHandler : IRequestHandler<CreateServiceToCounterCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateServiceToCounterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Unit> Handle(CreateServiceToCounterCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.CreateServiceToCounter(request.ServiceId, request.CounterId);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

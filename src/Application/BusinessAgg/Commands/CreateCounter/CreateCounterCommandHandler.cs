namespace AsanNobat.Application.BusinessAgg.Commands.CreateCounter;

public class CreateCounterCommandHandler : IRequestHandler<CreateCounterCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCounterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCounterCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        var counter = business.CreateCounter(request.Name, request.IsActive);

        await _context.SaveChangesAsync(cancellationToken);

        return counter.Id;
    }
}

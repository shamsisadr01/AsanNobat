namespace AsanNobat.Application.BusinessAgg.Commands.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateServiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        var service = business.CreateService(
            request.Name,
            request.Description,
            request.IsActive,
            request.LogoUrl,
            request.Mode,
            request.AverageServiceTimeMinutes);

        await _context.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}

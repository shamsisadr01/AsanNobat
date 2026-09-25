namespace AsanNobat.Application.BusinessAgg.Commands.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateServiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FindAsync([request.BusinessId], cancellationToken);

        Guard.Against.NotFound(request.BusinessId, business);

        business.UpdateService(
            request.ServiceId,
            request.Name,
            request.Description,
            request.IsActive,
            request.LogoUrl,
            request.Mode,
            request.AverageServiceTimeMinutes);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

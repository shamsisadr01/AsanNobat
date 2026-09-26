namespace AsanNobat.Application.BusinessAgg.Commands.UpdateBusiness;

public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async ValueTask<Unit> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Businesses
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Update(request.Name, "slug" + Guid.NewGuid(), request.Description, request.PhoneNumber, request.Address);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

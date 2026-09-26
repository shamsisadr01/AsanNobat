namespace AsanNobat.Application.BusinessAgg.Commands.CreateBusiness;

internal class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<int> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        var entity = Business.Create(request.Name, "slug" + Guid.NewGuid(), request.Description, request.PhoneNumber, request.Address);

        _context.Businesses.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

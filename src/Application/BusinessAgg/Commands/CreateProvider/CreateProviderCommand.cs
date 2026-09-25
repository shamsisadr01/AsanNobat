namespace AsanNobat.Application.BusinessAgg.Commands.CreateProvider;

public class CreateProviderCommand : IRequest<int>
{
    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}

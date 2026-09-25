namespace AsanNobat.Application.BusinessAgg.Commands.UpdateProvider;

public class UpdateProviderCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}

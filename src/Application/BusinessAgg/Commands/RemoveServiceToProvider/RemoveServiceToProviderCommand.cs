namespace AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToProvider;

public class RemoveServiceToProviderCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public int ProviderId { get; set; }
}

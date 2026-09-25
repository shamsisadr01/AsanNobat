namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToProvider;

public class CreateServiceToProviderCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public int ProviderId { get; set; }
}

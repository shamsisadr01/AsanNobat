namespace AsanNobat.Application.BusinessAgg.Commands.RemoveProvider;

public class RemoveProviderCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ProviderId { get; set; }
}

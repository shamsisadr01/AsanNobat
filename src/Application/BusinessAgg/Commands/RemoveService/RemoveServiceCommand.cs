namespace AsanNobat.Application.BusinessAgg.Commands.RemoveService;

public class RemoveServiceCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }
}

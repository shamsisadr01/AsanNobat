namespace AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToCounter;

public class RemoveServiceToCounterCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public int CounterId { get; set; }
}

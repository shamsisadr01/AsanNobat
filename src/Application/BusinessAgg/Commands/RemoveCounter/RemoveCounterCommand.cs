namespace AsanNobat.Application.BusinessAgg.Commands.RemoveCounter;

public class RemoveCounterCommand : IRequest
{
    public int BusinessId { get; set; }

    public int CounterId { get; set; }
}

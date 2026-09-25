namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToCounter;

public class CreateServiceToCounterCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public int CounterId { get; set; }
}

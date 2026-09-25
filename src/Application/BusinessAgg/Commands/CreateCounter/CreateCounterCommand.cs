namespace AsanNobat.Application.BusinessAgg.Commands.CreateCounter;

public class CreateCounterCommand : IRequest<int>
{
    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}

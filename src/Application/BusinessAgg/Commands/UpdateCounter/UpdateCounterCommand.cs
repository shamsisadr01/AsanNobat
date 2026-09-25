namespace AsanNobat.Application.BusinessAgg.Commands.UpdateCounter;

public class UpdateCounterCommand : IRequest
{
    public int BusinessId { get; set; }

    public int CounterId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }
}

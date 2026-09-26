namespace AsanNobat.Application.BusinessAgg.Commands.CreateBusiness;

public class CreateBusinessCommand : IRequest<int>
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;
}

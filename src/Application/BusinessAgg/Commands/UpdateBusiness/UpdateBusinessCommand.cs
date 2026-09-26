namespace AsanNobat.Application.BusinessAgg.Commands.UpdateBusiness;

public class UpdateBusinessCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
}

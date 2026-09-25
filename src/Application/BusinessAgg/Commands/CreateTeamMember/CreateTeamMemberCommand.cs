using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Application.BusinessAgg.Commands.CreateTeamMember;

public class CreateTeamMemberCommand : IRequest<int>
{
    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public string PinHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TeamRole Role { get; set; }
}

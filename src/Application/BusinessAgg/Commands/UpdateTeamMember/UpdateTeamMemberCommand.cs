using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Application.BusinessAgg.Commands.UpdateTeamMember;

public class UpdateTeamMemberCommand : IRequest
{
    public int BusinessId { get; set; }

    public int TeamMemberId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TeamRole Role { get; set; }
}

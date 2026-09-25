namespace AsanNobat.Application.BusinessAgg.Commands.RemoveTeamMember;

public class RemoveTeamMemberCommand : IRequest
{
    public int BusinessId { get; set; }

    public int TeamMemberId { get; set; }
}

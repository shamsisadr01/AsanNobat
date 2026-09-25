namespace AsanNobat.Application.BusinessAgg.Commands.RemoveTeamMember;

public class RemoveTeamMemberCommandValidator : AbstractValidator<RemoveTeamMemberCommand>
{
    public RemoveTeamMemberCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.TeamMemberId)
            .GreaterThan(0)
            .WithMessage("TeamMemberId is required.");
    }
}

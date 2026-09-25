namespace AsanNobat.Application.BusinessAgg.Commands.UpdateTeamMember;

public class UpdateTeamMemberCommandValidator : AbstractValidator<UpdateTeamMemberCommand>
{
    public UpdateTeamMemberCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.TeamMemberId)
            .GreaterThan(0)
            .WithMessage("TeamMemberId is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not a valid email address.");

        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Role is not a valid value.");
    }
}

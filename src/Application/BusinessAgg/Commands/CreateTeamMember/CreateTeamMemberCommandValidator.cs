namespace AsanNobat.Application.BusinessAgg.Commands.CreateTeamMember;

public class CreateTeamMemberCommandValidator : AbstractValidator<CreateTeamMemberCommand>
{
    public CreateTeamMemberCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.PinHash)
            .NotEmpty()
            .WithMessage("PinHash is required.");

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

namespace AsanNobat.Application.BusinessAgg.Commands.UpdateBusiness;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("Name is required.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber is required.");
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.");
    }
}

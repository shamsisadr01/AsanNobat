namespace AsanNobat.Application.BusinessAgg.Commands.CreateBusiness;

public class CreateBusinessCommandValidator : AbstractValidator<CreateBusinessCommand>
{
    public CreateBusinessCommandValidator()
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

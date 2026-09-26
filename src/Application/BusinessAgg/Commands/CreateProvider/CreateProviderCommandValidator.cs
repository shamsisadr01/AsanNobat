namespace AsanNobat.Application.BusinessAgg.Commands.CreateProvider;

public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
    }
}

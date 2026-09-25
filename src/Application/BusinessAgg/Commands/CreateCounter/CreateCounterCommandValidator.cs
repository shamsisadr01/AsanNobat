namespace AsanNobat.Application.BusinessAgg.Commands.CreateCounter;

public class CreateCounterCommandValidator : AbstractValidator<CreateCounterCommand>
{
    public CreateCounterCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
    }
}

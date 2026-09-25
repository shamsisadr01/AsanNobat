namespace AsanNobat.Application.BusinessAgg.Commands.CreateService;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.AverageServiceTimeMinutes)
            .GreaterThan(0)
            .WithMessage("AverageServiceTimeMinutes must be greater than zero.");
    }
}

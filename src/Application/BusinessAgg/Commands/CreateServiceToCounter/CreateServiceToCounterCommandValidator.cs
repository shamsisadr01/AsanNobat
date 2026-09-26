namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToCounter;

public class CreateServiceToCounterCommandValidator : AbstractValidator<CreateServiceToCounterCommand>
{
    public CreateServiceToCounterCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.ServiceId)
            .GreaterThan(0)
            .WithMessage("ServiceId is required.");

        RuleFor(x => x.CounterId)
            .GreaterThan(0)
            .WithMessage("CounterId is required.");
    }
}

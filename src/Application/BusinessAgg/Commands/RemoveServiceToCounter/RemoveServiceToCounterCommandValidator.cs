namespace AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToCounter;

public class RemoveServiceToCounterCommandValidator : AbstractValidator<RemoveServiceToCounterCommand>
{
    public RemoveServiceToCounterCommandValidator()
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

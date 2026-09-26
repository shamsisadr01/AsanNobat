namespace AsanNobat.Application.BusinessAgg.Commands.RemoveCounter;

public class RemoveCounterCommandValidator : AbstractValidator<RemoveCounterCommand>
{
    public RemoveCounterCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.CounterId)
            .GreaterThan(0)
            .WithMessage("CounterId is required.");
    }
}

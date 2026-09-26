namespace AsanNobat.Application.BusinessAgg.Commands.RemoveService;

public class RemoveServiceCommandValidator : AbstractValidator<RemoveServiceCommand>
{
    public RemoveServiceCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.ServiceId)
            .GreaterThan(0)
            .WithMessage("ServiceId is required.");
    }
}

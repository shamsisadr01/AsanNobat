namespace AsanNobat.Application.BusinessAgg.Commands.RemoveProvider;

public class RemoveProviderCommandValidator : AbstractValidator<RemoveProviderCommand>
{
    public RemoveProviderCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.ProviderId)
            .GreaterThan(0)
            .WithMessage("ProviderId is required.");
    }
}

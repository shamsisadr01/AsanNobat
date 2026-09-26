namespace AsanNobat.Application.BusinessAgg.Commands.CreateServiceToProvider;

public class CreateServiceToProviderCommandValidator : AbstractValidator<CreateServiceToProviderCommand>
{
    public CreateServiceToProviderCommandValidator()
    {
        RuleFor(x => x.BusinessId)
            .GreaterThan(0)
            .WithMessage("BusinessId is required.");

        RuleFor(x => x.ServiceId)
            .GreaterThan(0)
            .WithMessage("ServiceId is required.");

        RuleFor(x => x.ProviderId)
            .GreaterThan(0)
            .WithMessage("ProviderId is required.");
    }
}

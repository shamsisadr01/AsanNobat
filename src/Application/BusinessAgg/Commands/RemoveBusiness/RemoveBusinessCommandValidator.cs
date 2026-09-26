namespace AsanNobat.Application.BusinessAgg.Commands.RemoveBusiness;

public class RemoveBusinessCommandValidator : AbstractValidator<RemoveBusinessCommand>
{
    public RemoveBusinessCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id is required.");
    }
}

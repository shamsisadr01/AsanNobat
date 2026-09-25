using AsanNobat.Domain.BusinessAgg.Enums;

namespace AsanNobat.Application.BusinessAgg.Commands.UpdateService;

public class UpdateServiceCommand : IRequest
{
    public int BusinessId { get; set; }

    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? LogoUrl { get; set; }

    public ServiceMode Mode { get; set; }

    public int AverageServiceTimeMinutes { get; set; }
}

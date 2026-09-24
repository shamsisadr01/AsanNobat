using System;
using System.Collections.Generic;
using System.Text;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Provider : BaseEntity
{
    public int BusinessId { get; private set; }

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private readonly List<Service> _services = [];

    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();
}

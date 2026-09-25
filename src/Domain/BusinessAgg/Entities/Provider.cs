using System;
using System.Collections.Generic;
using System.Text;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg.Entities;

public class Provider : BaseEntity
{
    public int BusinessId { get; internal set; }

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private readonly List<Service> _services = [];
    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

    private Provider()
    {
        
    }

    internal Provider(int businessId, string name, bool isActive)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        BusinessId = businessId;
        Name = name;
        IsActive = isActive;
    }

    public void Update(string name, bool isActive)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        Name = name;
        IsActive = isActive;
    }

    public void AddService(Service service)
    {
        _services.Add(service);
    }

    public void RemoveService(Service service)
    {
        _services.Remove(service);
    }
}

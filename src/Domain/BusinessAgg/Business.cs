using AsanNobat.Domain.BusinessAgg.Entities;
using AsanNobat.Domain.BusinessAgg.Enums;
using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.BusinessAgg;

public class Business : Aggregate
{
    public string Name { get; private set; } = null!;
    public string UrlSlug { get; private set; } = null!;
    public string? Description { get; private set; }
    public string PhoneNumber { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    private readonly List<Service> _services = [];
    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

    private readonly List<Counter> _counters = [];
    public IReadOnlyCollection<Counter> Counters => _counters.AsReadOnly();

    private readonly List<TeamMember> _teamMembers = [];
    public IReadOnlyCollection<TeamMember> TeamMembers => _teamMembers.AsReadOnly();

    private readonly List<Provider> _providers = [];
    public IReadOnlyCollection<Provider> Providers => _providers.AsReadOnly();


    private Business()
    {
        
    }
    private Business(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        Guard(name, urlSlug, description, phoneNumber, address);
        Name = name;
        UrlSlug = urlSlug;
        Description = description;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public static Business Create(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        return new Business(name, urlSlug, description, phoneNumber, address);
    }

    public void Update(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        Guard(name, urlSlug, description, phoneNumber, address);
        Name = name;
        UrlSlug = urlSlug;
        Description = description;
        PhoneNumber = phoneNumber;
        Address = address;
    }


    public void Guard(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentException.ThrowIfNullOrEmpty(urlSlug, nameof(urlSlug));
        ArgumentException.ThrowIfNullOrEmpty(phoneNumber, nameof(phoneNumber));
        ArgumentException.ThrowIfNullOrEmpty(address, nameof(address));
    }


    public void AddService(string name, string? description, bool isActive, string? logoUrl, ServiceMode mode, int averageServiceTimeMinutes)
    {
        var service = new Service(name, description, isActive, logoUrl, mode, averageServiceTimeMinutes);
        _services.Add(service);
    }

    public void UpdateService(int serviceId, string name, string? description, bool isActive, string? logoUrl, ServiceMode mode, int averageServiceTimeMinutes)
    {
        var existingItem = Services.FirstOrDefault(x => x.Id == serviceId);
        if (existingItem != null)
        {
            existingItem.Update(name, description, isActive, logoUrl, mode, averageServiceTimeMinutes);
        }
    }

    public void RemoveService(int serviceId)
    {
        var existingItem = Services.FirstOrDefault(x => x.Id == serviceId);

        if (existingItem != null)
        {
            _services.Remove(existingItem);
        }
    }
}

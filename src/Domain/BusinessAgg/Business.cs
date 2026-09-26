using AsanNobat.Domain.BusinessAgg.Entities;
using AsanNobat.Domain.BusinessAgg.Enums;
using AsanNobat.Domain.BusinessAgg.Events;
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

    public void Remove()
    {
        AddDomainEvent(new BusinessDeletedEvent(this));
    }

    #region Operation Service

    public Service CreateService(string name, string? description, bool isActive, string? logoUrl, ServiceMode mode, int averageServiceTimeMinutes)
    {
        var service = new Service(name, description, isActive, logoUrl, mode, averageServiceTimeMinutes);
        _services.Add(service);

        return service;
    }

    public void UpdateService(int serviceId, string name, string? description, bool isActive, string? logoUrl, ServiceMode mode, int averageServiceTimeMinutes)
    {
        var existingItem = Services.FirstOrDefault(x => x.Id == serviceId);
        if (existingItem is not null)
        {
            existingItem.Update(name, description, isActive, logoUrl, mode, averageServiceTimeMinutes);
        }
    }

    public void RemoveService(int serviceId)
    {
        var existingItem = Services.FirstOrDefault(x => x.Id == serviceId);

        if (existingItem is not null)
        {
            _services.Remove(existingItem);
        }
    }

    #endregion


    #region Operation Provider
    public Provider CreateProvider(string name, bool isActive)
    {
        var provider = new Provider(Id, name, isActive);
        _providers.Add(provider);

        return provider;
    }

    public void UpdateProvider(int providerId, string name, bool isActive)
    {
        var existingItem = Providers.FirstOrDefault(x => x.Id == providerId);
        if (existingItem is not null)
        {
            existingItem.Update(name, isActive);
        }
    }

    public void RemoveProvider(int providerId)
    {
        var existingItem = Providers.FirstOrDefault(x => x.Id == providerId);

        if (existingItem is not null)
        {
            _providers.Remove(existingItem);
        }
    }

    public void CreateServiceToProvider(int serviceId, int providerId)
    {
        var provider = Providers.FirstOrDefault(x => x.Id == providerId);
        var service = Services.FirstOrDefault(x => x.Id == serviceId);

        if(service is not null && provider is not null)
        {
            provider.AddService(service);
        }
    }

    public void RemoveServiceToProvider(int serviceId, int providerId)
    {
        var provider = Providers.FirstOrDefault(x => x.Id == providerId);
        var service = Services.FirstOrDefault(x => x.Id == serviceId);

        if (service is not null && provider is not null)
        {
            provider.RemoveService(service);
        }
    }

    #endregion


    #region Operation Counter
    public Counter CreateCounter(string name, bool isActive, int? currentServingQueueEntryId = null)
    {
        var counter = new Counter(name, isActive, currentServingQueueEntryId);
        _counters.Add(counter);

        return counter;
    }

    public void UpdateCounter(int counterId, string name, bool isActive, int? currentServingQueueEntryId = null)
    {
        var existingItem = Counters.FirstOrDefault(x => x.Id == counterId);
        if (existingItem is not null)
        {
            existingItem.Update(name, isActive, currentServingQueueEntryId);
        }
    }

    public void RemoveCounter(int counterId)
    {
        var existingItem = Counters.FirstOrDefault(x => x.Id == counterId);

        if (existingItem is not null)
        {
            _counters.Remove(existingItem);
        }
    }

    public void CreateServiceToCounter(int serviceId, int counterId)
    {
        var counter = Counters.FirstOrDefault(x => x.Id == counterId);
        var service = Services.FirstOrDefault(x => x.Id == serviceId);

        if (service is not null && counter is not null)
        {
            counter.AddService(service);
        }
    }

    public void RemoveServiceToCounter(int serviceId, int counterId)
    {
        var counter = Counters.FirstOrDefault(x => x.Id == counterId);
        var service = Services.FirstOrDefault(x => x.Id == serviceId);

        if (service is not null && counter is not null)
        {
            counter.RemoveService(service);
        }
    }

    #endregion


    #region Operation TeamMember
    public TeamMember CreateTeamMember(string name, string pinHash, string email, TeamRole role)
    {
        var teamMember = new TeamMember(Id, name, pinHash, email, role);
        _teamMembers.Add(teamMember);

        return teamMember;
    }

    public void UpdateTeamMember(int teamMemberId, string name, string email, TeamRole role)
    {
        var existingItem = TeamMembers.FirstOrDefault(x => x.Id == teamMemberId);
        if (existingItem is not null)
        {
            existingItem.Update(name, email, role);
        }
    }

    public void RemoveTeamMember(int teamMemberId)
    {
        var existingItem = TeamMembers.FirstOrDefault(x => x.Id == teamMemberId);
        if (existingItem is not null)
        {
            _teamMembers.Remove(existingItem);
        }
    }

    #endregion
}

using AsanNobat.Application.BusinessAgg.Commands.CreateBusiness;
using AsanNobat.Application.BusinessAgg.Queries.GetBusinesses;
using AsanNobat.Application.BusinessAgg.Queries.GetBusinessCounters;
using AsanNobat.Application.BusinessAgg.Queries.GetBusinessProviders;
using AsanNobat.Application.BusinessAgg.Queries.GetBusinessServices;
using AsanNobat.Application.BusinessAgg.Queries.GetBusinessTeamMembers;
using AsanNobat.Application.BusinessAgg.Commands.CreateCounter;
using AsanNobat.Application.BusinessAgg.Commands.CreateProvider;
using AsanNobat.Application.BusinessAgg.Commands.CreateService;
using AsanNobat.Application.BusinessAgg.Commands.CreateServiceToCounter;
using AsanNobat.Application.BusinessAgg.Commands.CreateServiceToProvider;
using AsanNobat.Application.BusinessAgg.Commands.CreateTeamMember;
using AsanNobat.Application.BusinessAgg.Commands.RemoveBusiness;
using AsanNobat.Application.BusinessAgg.Commands.RemoveCounter;
using AsanNobat.Application.BusinessAgg.Commands.RemoveProvider;
using AsanNobat.Application.BusinessAgg.Commands.RemoveService;
using AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToCounter;
using AsanNobat.Application.BusinessAgg.Commands.RemoveServiceToProvider;
using AsanNobat.Application.BusinessAgg.Commands.RemoveTeamMember;
using AsanNobat.Application.BusinessAgg.Commands.UpdateBusiness;
using AsanNobat.Application.BusinessAgg.Commands.UpdateCounter;
using AsanNobat.Application.BusinessAgg.Commands.UpdateProvider;
using AsanNobat.Application.BusinessAgg.Commands.UpdateService;
using AsanNobat.Application.BusinessAgg.Commands.UpdateTeamMember;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AsanNobat.Web.Endpoints;

public class Business : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.RequireAuthorization();

        // Business
        groupBuilder.MapGet(GetBusinesses);
        groupBuilder.MapPost(CreateBusiness);
        groupBuilder.MapPut(UpdateBusiness, "{id}");
        groupBuilder.MapDelete(DeleteBusiness, "{id}");

        // Services
        groupBuilder.MapPost(CreateService, "Services");
        groupBuilder.MapPut(UpdateService, "Services/{serviceId}");
        groupBuilder.MapDelete(DeleteService, "{businessId}/Services/{serviceId}");

        // Providers
        groupBuilder.MapPost(CreateProvider, "Providers");
        groupBuilder.MapPut(UpdateProvider, "Providers/{providerId}");
        groupBuilder.MapDelete(DeleteProvider, "{businessId}/Providers/{providerId}");

        // Counters
        groupBuilder.MapPost(CreateCounter, "Counters");
        groupBuilder.MapPut(UpdateCounter, "Counters/{counterId}");
        groupBuilder.MapDelete(DeleteCounter, "{businessId}/Counters/{counterId}");

        // Service <-> Provider
        groupBuilder.MapPost(AssignServiceToProvider, "ServiceToProvider");
        groupBuilder.MapDelete(UnassignServiceFromProvider, "ServiceToProvider/{businessId}/{serviceId}/{providerId}");

        // Service <-> Counter
        groupBuilder.MapPost(AssignServiceToCounter, "ServiceToCounter");
        groupBuilder.MapDelete(UnassignServiceFromCounter, "ServiceToCounter/{businessId}/{serviceId}/{counterId}");

        // Child lists
        groupBuilder.MapGet(GetBusinessServices, "{businessId}/Services");
        groupBuilder.MapGet(GetBusinessProviders, "{businessId}/Providers");
        groupBuilder.MapGet(GetBusinessCounters, "{businessId}/Counters");
        groupBuilder.MapGet(GetBusinessTeamMembers, "{businessId}/TeamMembers");

        // Team Members
        groupBuilder.MapPost(CreateTeamMember, "TeamMembers");
        groupBuilder.MapPut(UpdateTeamMember, "TeamMembers/{teamMemberId}");
        groupBuilder.MapDelete(DeleteTeamMember, "{businessId}/TeamMembers/{teamMemberId}");
    }

    #region Business

    [EndpointSummary("Get all Businesses")]
    [EndpointDescription("Returns all businesses.")]
    public static async Task<Ok<BusinessesVm>> GetBusinesses(ISender sender)
    {
        return TypedResults.Ok(await sender.Send(new GetBusinessesQuery()));
    }

    [EndpointSummary("Get business Services")]
    [EndpointDescription("Returns all services of the specified business.")]
    public static async Task<Results<Ok<ServicesVm>, NotFound>> GetBusinessServices(ISender sender, int businessId)
    {
        return TypedResults.Ok(await sender.Send(new GetBusinessServicesQuery(businessId)));
    }

    [EndpointSummary("Get business Providers")]
    [EndpointDescription("Returns all providers of the specified business including their linked services.")]
    public static async Task<Results<Ok<ProvidersVm>, NotFound>> GetBusinessProviders(ISender sender, int businessId)
    {
        return TypedResults.Ok(await sender.Send(new GetBusinessProvidersQuery(businessId)));
    }

    [EndpointSummary("Get business Counters")]
    [EndpointDescription("Returns all counters of the specified business including their assigned services.")]
    public static async Task<Results<Ok<CountersVm>, NotFound>> GetBusinessCounters(ISender sender, int businessId)
    {
        return TypedResults.Ok(await sender.Send(new GetBusinessCountersQuery(businessId)));
    }

    [EndpointSummary("Get business Team Members")]
    [EndpointDescription("Returns all team members of the specified business.")]
    public static async Task<Results<Ok<TeamMembersVm>, NotFound>> GetBusinessTeamMembers(ISender sender, int businessId)
    {
        return TypedResults.Ok(await sender.Send(new GetBusinessTeamMembersQuery(businessId)));
    }

    [EndpointSummary("Create a new Business")]
    [EndpointDescription("Creates a new business using the provided details and returns the ID of the created business.")]
    public static async Task<Created<int>> CreateBusiness(ISender sender, CreateBusinessCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/api/Business/{id}", id);
    }

    [EndpointSummary("Update a Business")]
    [EndpointDescription("Updates the specified business. The ID in the URL must match the ID in the payload.")]
    public static async Task<Results<NoContent, BadRequest>> UpdateBusiness(ISender sender, int id, UpdateBusinessCommand command)
    {
        if (id != command.Id)
            return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Delete a Business")]
    [EndpointDescription("Deletes the business with the specified ID.")]
    public static async Task<NoContent> DeleteBusiness(ISender sender, int id)
    {
        await sender.Send(new RemoveBusinessCommand { Id = id });

        return TypedResults.NoContent();
    }

    #endregion

    #region Services

    [EndpointSummary("Create a new Service")]
    [EndpointDescription("Creates a new service for the specified business and returns the ID of the created service.")]
    public static async Task<Created<int>> CreateService(ISender sender, CreateServiceCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/api/Business/Services/{id}", id);
    }

    [EndpointSummary("Update a Service")]
    [EndpointDescription("Updates the specified service of a business. The service ID in the URL must match the ID in the payload.")]
    public static async Task<Results<NoContent, BadRequest>> UpdateService(ISender sender, int serviceId, UpdateServiceCommand command)
    {
        if (serviceId != command.ServiceId)
            return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Delete a Service")]
    [EndpointDescription("Deletes the service with the specified ID from the specified business.")]
    public static async Task<NoContent> DeleteService(ISender sender, int businessId, int serviceId)
    {
        await sender.Send(new RemoveServiceCommand { BusinessId = businessId, ServiceId = serviceId });

        return TypedResults.NoContent();
    }

    #endregion

    #region Providers

    [EndpointSummary("Create a new Provider")]
    [EndpointDescription("Creates a new provider for the specified business and returns the ID of the created provider.")]
    public static async Task<Created<int>> CreateProvider(ISender sender, CreateProviderCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/api/Business/Providers/{id}", id);
    }

    [EndpointSummary("Update a Provider")]
    [EndpointDescription("Updates the specified provider of a business. The provider ID in the URL must match the ID in the payload.")]
    public static async Task<Results<NoContent, BadRequest>> UpdateProvider(ISender sender, int providerId, UpdateProviderCommand command)
    {
        if (providerId != command.ProviderId)
            return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Delete a Provider")]
    [EndpointDescription("Deletes the provider with the specified ID from the specified business.")]
    public static async Task<NoContent> DeleteProvider(ISender sender, int businessId, int providerId)
    {
        await sender.Send(new RemoveProviderCommand { BusinessId = businessId, ProviderId = providerId });

        return TypedResults.NoContent();
    }

    #endregion

    #region Counters

    [EndpointSummary("Create a new Counter")]
    [EndpointDescription("Creates a new counter for the specified business and returns the ID of the created counter.")]
    public static async Task<Created<int>> CreateCounter(ISender sender, CreateCounterCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/api/Business/Counters/{id}", id);
    }

    [EndpointSummary("Update a Counter")]
    [EndpointDescription("Updates the specified counter of a business. The counter ID in the URL must match the ID in the payload.")]
    public static async Task<Results<NoContent, BadRequest>> UpdateCounter(ISender sender, int counterId, UpdateCounterCommand command)
    {
        if (counterId != command.CounterId)
            return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Delete a Counter")]
    [EndpointDescription("Deletes the counter with the specified ID from the specified business.")]
    public static async Task<NoContent> DeleteCounter(ISender sender, int businessId, int counterId)
    {
        await sender.Send(new RemoveCounterCommand { BusinessId = businessId, CounterId = counterId });

        return TypedResults.NoContent();
    }

    #endregion

    #region Service <-> Provider

    [EndpointSummary("Assign a service to a provider")]
    [EndpointDescription("Assigns the specified service to the specified provider within a business.")]
    public static async Task<NoContent> AssignServiceToProvider(ISender sender, CreateServiceToProviderCommand command)
    {
        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Unassign a service from a provider")]
    [EndpointDescription("Removes the specified service from the specified provider within a business.")]
    public static async Task<NoContent> UnassignServiceFromProvider(ISender sender, int businessId, int serviceId, int providerId)
    {
        await sender.Send(new RemoveServiceToProviderCommand { BusinessId = businessId, ServiceId = serviceId, ProviderId = providerId });

        return TypedResults.NoContent();
    }

    #endregion

    #region Service <-> Counter

    [EndpointSummary("Assign a service to a counter")]
    [EndpointDescription("Assigns the specified service to the specified counter within a business.")]
    public static async Task<NoContent> AssignServiceToCounter(ISender sender, CreateServiceToCounterCommand command)
    {
        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Unassign a service from a counter")]
    [EndpointDescription("Removes the specified service from the specified counter within a business.")]
    public static async Task<NoContent> UnassignServiceFromCounter(ISender sender, int businessId, int serviceId, int counterId)
    {
        await sender.Send(new RemoveServiceToCounterCommand { BusinessId = businessId, ServiceId = serviceId, CounterId = counterId });

        return TypedResults.NoContent();
    }

    #endregion

    #region Team Members

    [EndpointSummary("Create a new Team Member")]
    [EndpointDescription("Creates a new team member for the specified business and returns the ID of the created team member.")]
    public static async Task<Created<int>> CreateTeamMember(ISender sender, CreateTeamMemberCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/api/Business/TeamMembers/{id}", id);
    }

    [EndpointSummary("Update a Team Member")]
    [EndpointDescription("Updates the specified team member of a business. The team member ID in the URL must match the ID in the payload.")]
    public static async Task<Results<NoContent, BadRequest>> UpdateTeamMember(ISender sender, int teamMemberId, UpdateTeamMemberCommand command)
    {
        if (teamMemberId != command.TeamMemberId)
            return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    [EndpointSummary("Delete a Team Member")]
    [EndpointDescription("Deletes the team member with the specified ID from the specified business.")]
    public static async Task<NoContent> DeleteTeamMember(ISender sender, int businessId, int teamMemberId)
    {
        await sender.Send(new RemoveTeamMemberCommand { BusinessId = businessId, TeamMemberId = teamMemberId });

        return TypedResults.NoContent();
    }

    #endregion
}

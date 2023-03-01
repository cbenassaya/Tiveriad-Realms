using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Multitenancy.Apis.Filters;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Apis.Filters;

public class DomainEventActionFilter : IAsyncActionFilter
{
    private readonly IDomainEventStore _store;
    private readonly IPublisher<RoleDomainEvent, string> _roleDomainEventPublisher;
    private readonly IPublisher<FeatureDomainEvent, string> _featureDomainEventPublisher;
    private readonly IPublisher<ModuleDomainEvent, string> _moduleEventPublisher;


    public DomainEventActionFilter(IDomainEventStore store, IPublisher<RoleDomainEvent, string> roleDomainEventPublisher, IPublisher<FeatureDomainEvent, string> featureDomainEventPublisher, IPublisher<ModuleDomainEvent, string> moduleEventPublisher)
    {
        _store = store;
        _roleDomainEventPublisher = roleDomainEventPublisher;
        _featureDomainEventPublisher = featureDomainEventPublisher;
        _moduleEventPublisher = moduleEventPublisher;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            _store.Commit();
            
            foreach (var entry in _store.Entries<RoleDomainEvent, string>())
                await _roleDomainEventPublisher.Publish(entry);
            
            foreach (var entry in _store.Entries<FeatureDomainEvent, string>())
                await _featureDomainEventPublisher.Publish(entry);
            
            foreach (var entry in _store.Entries<ModuleDomainEvent, string>())
                await _moduleEventPublisher.Publish(entry);
        }
    }
}
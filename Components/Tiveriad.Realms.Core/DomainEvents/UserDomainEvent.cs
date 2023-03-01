using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Core.DomainEvents;

public class RoleDomainEvent:IDomainEvent<string>
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
    public Role Role { get; set; }
    public string EventType  { get; set; }
}

public class FeatureDomainEvent:IDomainEvent<string>
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
    public Feature Feature { get; set; }
    public string EventType  { get; set; }
}

public class ModuleDomainEvent:IDomainEvent<string>
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
    public Module Module { get; set; }
    public string EventType  { get; set; }
}
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Infrastructure.Publishers;

public class ModuleDomainEventPublisher: RabbitMqPublisher<ModuleDomainEvent, string>
{
    public ModuleDomainEventPublisher(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        string eventName,
        ILogger<ModuleDomainEventPublisher> logger) : base(connectionFactory, configuration, eventName, logger)
    {
    }
}
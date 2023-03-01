using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Infrastructure.Publishers;

public class FeatureDomainEventPublisher: RabbitMqPublisher<FeatureDomainEvent, string>
{
    public FeatureDomainEventPublisher(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        string eventName,
        ILogger<FeatureDomainEventPublisher> logger) : base(connectionFactory, configuration, eventName, logger)
    {
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.Realms.Core.DomainEvents;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Realms.Core.Services;
using Tiveriad.Realms.Infrastructure.Publishers;
using Tiveriad.Realms.Infrastructure.Services;
using Tiveriad.Realms.Persistence;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;

namespace Tiveriad.Realms.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextPool<DbContext, DefaultContext>(options =>
        {
            var logger = services.BuildServiceProvider().GetService<ILogger<DefaultContext>>();
            if (logger!=null) 
                options.LogTo(message => { logger.LogInformation(message); }).EnableSensitiveDataLogging().EnableDetailedErrors();
            options.UseSqlite("Data Source=multi-tenancy.db");
        });
        services.AddRepositories(typeof(EFRepository<, >), typeof(Role));
        services.AddTransient<IUserManagerService, UserManagerService>();
        services.AddSingleton<IPublisher<ModuleDomainEvent, string>>(sp => new ModuleDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(ModuleDomainEvent).FullName,
            sp.GetRequiredService<ILogger<ModuleDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<RoleDomainEvent, string>>(sp => new RoleDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(RoleDomainEvent).FullName,
            sp.GetRequiredService<ILogger<RoleDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<FeatureDomainEvent, string>>(sp => new FeatureDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(FeatureDomainEvent).FullName,
            sp.GetRequiredService<ILogger<FeatureDomainEventPublisher>>()));
        return services;
    }
}

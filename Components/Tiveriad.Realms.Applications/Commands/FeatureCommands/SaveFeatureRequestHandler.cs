using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;
public class SaveFeatureRequestHandler : IRequestHandler<SaveFeatureRequest, Feature>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IDomainEventStore _store;
    public SaveFeatureRequestHandler(IRepository<Feature, string> featureRepository, IDomainEventStore store)
    {
        _featureRepository = featureRepository;
        _store = store;
    }

    public Task<Feature> Handle(SaveFeatureRequest request, CancellationToken cancellationToken)
    {
        var query = _featureRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Feature.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _featureRepository.AddOneAsync(request.Feature, cancellationToken);
            _store.Add<FeatureDomainEvent,string>( new FeatureDomainEvent() {Feature = request.Feature, EventType = "INSERT"});
            return request.Feature;
        //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
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
public class UpdateFeatureRequestHandler : IRequestHandler<UpdateFeatureRequest, Feature>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IDomainEventStore _store;
    public UpdateFeatureRequestHandler(IRepository<Feature, string> featureRepository, IDomainEventStore store)
    {
        _featureRepository = featureRepository;
        _store = store;
    }

    public Task<Feature> Handle(UpdateFeatureRequest request, CancellationToken cancellationToken)
    {
        var query = _featureRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Feature.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.ToList().FirstOrDefault();
            if (result == null)
            {
                throw new Exception();
            }
            else
            {
                result.Key = request.Feature.Key;
                result.Name = request.Feature.Name;
                result.Description = request.Feature.Description;
                result.State = request.Feature.State;
                _store.Add<FeatureDomainEvent,string>( new FeatureDomainEvent() {Feature = result, EventType = "UPDATE"});
                return result;
            }
        //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
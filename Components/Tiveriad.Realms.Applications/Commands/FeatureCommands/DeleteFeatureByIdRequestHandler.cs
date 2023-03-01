using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;
public class DeleteFeatureByIdRequestHandler : IRequestHandler<DeleteFeatureByIdRequest, bool>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IDomainEventStore _store;
    public DeleteFeatureByIdRequestHandler(IRepository<Feature, string> featureRepository, IDomainEventStore store)
    {
        _featureRepository = featureRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteFeatureByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var feature = _featureRepository.GetById(request.Id);
            var result = _featureRepository.DeleteOne(feature) == 1;
            if (result)
                _store.Add<FeatureDomainEvent, string>(new FeatureDomainEvent()
                    { Feature = feature, EventType = "DELETE" });
            return result;
        });
        //<-- END CUSTOM CODE-->
    }
}
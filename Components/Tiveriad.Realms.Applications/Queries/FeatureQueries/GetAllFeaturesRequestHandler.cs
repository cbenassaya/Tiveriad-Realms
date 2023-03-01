using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;
public class GetAllFeaturesRequestHandler : IRequestHandler<GetAllFeaturesRequest, IEnumerable<Feature>>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Module, string> _moduleRepository;
    public GetAllFeaturesRequestHandler(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }

    public Task<IEnumerable<Feature>> Handle(GetAllFeaturesRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _featureRepository.Queryable.Include(x => x.Module);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}
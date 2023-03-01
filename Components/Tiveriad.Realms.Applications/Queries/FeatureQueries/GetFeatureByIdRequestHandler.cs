using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;
public class GetFeatureByIdRequestHandler : IRequestHandler<GetFeatureByIdRequest, Feature>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Module, string> _moduleRepository;
    public GetFeatureByIdRequestHandler(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }

    public Task<Feature> Handle(GetFeatureByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _featureRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}
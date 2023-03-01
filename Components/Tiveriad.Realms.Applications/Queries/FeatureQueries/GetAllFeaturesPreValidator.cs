using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;
public class GetAllFeaturesPreValidator : AbstractValidator<GetAllFeaturesRequest>
{
    private IRepository<Feature, string> _featureRepository;
    private IRepository<Module, string> _moduleRepository;
    public GetAllFeaturesPreValidator(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }
}
using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;
public class GetFeatureByIdPreValidator : AbstractValidator<GetFeatureByIdRequest>
{
    private IRepository<Feature, string> _featureRepository;
    private IRepository<Module, string> _moduleRepository;
    public GetFeatureByIdPreValidator(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }
}
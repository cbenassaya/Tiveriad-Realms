using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;
public class SaveFeaturePreValidator : AbstractValidator<SaveFeatureRequest>
{
    private IRepository<Feature, string> _featureRepository;
    private IRepository<Module, string> _moduleRepository;
    public SaveFeaturePreValidator(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }
}
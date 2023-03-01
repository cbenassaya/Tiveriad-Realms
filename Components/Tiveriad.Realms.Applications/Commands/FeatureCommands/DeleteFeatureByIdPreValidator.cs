using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;
public class DeleteFeatureByIdPreValidator : AbstractValidator<DeleteFeatureByIdRequest>
{
    private IRepository<Feature, string> _featureRepository;
    private IRepository<Module, string> _moduleRepository;
    public DeleteFeatureByIdPreValidator(IRepository<Feature, string> featureRepository, IRepository<Module, string> moduleRepository)
    {
        _featureRepository = featureRepository;
        _moduleRepository = moduleRepository;
    }
}
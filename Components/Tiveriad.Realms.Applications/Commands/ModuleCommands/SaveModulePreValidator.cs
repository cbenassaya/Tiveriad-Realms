using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;
public class SaveModulePreValidator : AbstractValidator<SaveModuleRequest>
{
    private IRepository<Module, string> _moduleRepository;
    public SaveModulePreValidator(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }
}
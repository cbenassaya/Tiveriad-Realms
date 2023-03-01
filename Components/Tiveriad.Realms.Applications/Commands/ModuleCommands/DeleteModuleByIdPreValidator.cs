using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;
public class DeleteModuleByIdPreValidator : AbstractValidator<DeleteModuleByIdRequest>
{
    private IRepository<Module, string> _moduleRepository;
    public DeleteModuleByIdPreValidator(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }
}
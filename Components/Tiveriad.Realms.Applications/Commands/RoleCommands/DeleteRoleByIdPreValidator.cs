using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;
public class DeleteRoleByIdPreValidator : AbstractValidator<DeleteRoleByIdRequest>
{
    private IRepository<Role, string> _roleRepository;
    private IRepository<Module, string> _moduleRepository;
    public DeleteRoleByIdPreValidator(IRepository<Role, string> roleRepository, IRepository<Module, string> moduleRepository)
    {
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;
    }
}
using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;
using System.Data;
using FluentValidation.Results;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;
public class SaveRolePreValidator : AbstractValidator<SaveRoleRequest>
{
    private IRepository<Role, string> _roleRepository;
    private IRepository<Module, string> _moduleRepository;
    public SaveRolePreValidator(IRepository<Role, string> roleRepository, IRepository<Module, string> moduleRepository)
    {
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;

        RuleFor(x => x.Role.Name).NotEmpty();
        RuleFor(x => x.Role).Must(NameUniqued);
    }
    
    
    private bool NameUniqued(Role value)
    {
        return !_roleRepository.Find(x => x.Name == value.Name && x.Id != value.Id).Any();
    }


}
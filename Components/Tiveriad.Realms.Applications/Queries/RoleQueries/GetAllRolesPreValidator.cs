using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Queries.RoleQueries;
public class GetAllRolesPreValidator : AbstractValidator<GetAllRolesRequest>
{
    private IRepository<Role, string> _roleRepository;
    private IRepository<Module, string> _moduleRepository;
    public GetAllRolesPreValidator(IRepository<Role, string> roleRepository, IRepository<Module, string> moduleRepository)
    {
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;
    }
}
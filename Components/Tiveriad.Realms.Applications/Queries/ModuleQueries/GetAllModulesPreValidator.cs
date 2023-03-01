using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;
public class GetAllModulesPreValidator : AbstractValidator<GetAllModulesRequest>
{
    private IRepository<Module, string> _moduleRepository;
    public GetAllModulesPreValidator(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }
}
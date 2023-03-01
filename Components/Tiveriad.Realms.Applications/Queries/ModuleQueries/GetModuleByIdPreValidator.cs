using FluentValidation;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;
public class GetModuleByIdPreValidator : AbstractValidator<GetModuleByIdRequest>
{
    private IRepository<Module, string> _moduleRepository;
    public GetModuleByIdPreValidator(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }
}
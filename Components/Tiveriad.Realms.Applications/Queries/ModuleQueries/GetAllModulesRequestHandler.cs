using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;
public class GetAllModulesRequestHandler : IRequestHandler<GetAllModulesRequest, IEnumerable<Module>>
{
    private readonly IRepository<Module, string> _moduleRepository;
    public GetAllModulesRequestHandler(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task<IEnumerable<Module>> Handle(GetAllModulesRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _moduleRepository.Queryable;
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}
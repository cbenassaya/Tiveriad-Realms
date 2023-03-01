using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.RoleQueries;
public class GetAllRolesRequestHandler : IRequestHandler<GetAllRolesRequest, IEnumerable<Role>>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IRepository<Module, string> _moduleRepository;
    public GetAllRolesRequestHandler(IRepository<Role, string> roleRepository, IRepository<Module, string> moduleRepository)
    {
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;
    }

    public Task<IEnumerable<Role>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _roleRepository.Queryable.Include(x => x.Module);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}
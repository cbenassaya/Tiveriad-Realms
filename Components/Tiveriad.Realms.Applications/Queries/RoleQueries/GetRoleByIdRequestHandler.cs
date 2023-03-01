using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.RoleQueries;
public class GetRoleByIdRequestHandler : IRequestHandler<GetRoleByIdRequest, Role>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IRepository<Module, string> _moduleRepository;
    public GetRoleByIdRequestHandler(IRepository<Role, string> roleRepository, IRepository<Module, string> moduleRepository)
    {
        _roleRepository = roleRepository;
        _moduleRepository = moduleRepository;
    }

    public Task<Role> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _roleRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}
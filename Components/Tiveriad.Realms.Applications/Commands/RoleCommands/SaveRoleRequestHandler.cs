using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;
public class SaveRoleRequestHandler : IRequestHandler<SaveRoleRequest, Role>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;
    public SaveRoleRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store)
    {
        _roleRepository = roleRepository;
        _store = store;
    }

    public Task<Role> Handle(SaveRoleRequest request, CancellationToken cancellationToken)
    {
        var query = _roleRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Role.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _roleRepository.AddOneAsync(request.Role, cancellationToken);
            _store.Add<RoleDomainEvent,string>( new RoleDomainEvent() {Role = request.Role, EventType = "INSERT"});
            return request.Role;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
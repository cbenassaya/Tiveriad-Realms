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
public class UpdateRoleRequestHandler : IRequestHandler<UpdateRoleRequest, Role>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;
    public UpdateRoleRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store)
    {
        _roleRepository = roleRepository;
        _store = store;
    }

    public Task<Role> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var query = _roleRepository.Queryable.Include(x => x.Module).Where(x => x.Id == request.Role.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.ToList().FirstOrDefault();
            if (result == null)
            {
                throw new Exception();
            }
            else
            {
                result.Key = request.Role.Key;
                result.Name = request.Role.Name;
                result.Description = request.Role.Description;
                result.State = request.Role.State;
                _store.Add<RoleDomainEvent,string>( new RoleDomainEvent() {Role = result, EventType = "UPDATE"});
                return result;
            }
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
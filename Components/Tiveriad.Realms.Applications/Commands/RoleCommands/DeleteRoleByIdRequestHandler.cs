using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;
public class DeleteRoleByIdRequestHandler : IRequestHandler<DeleteRoleByIdRequest, bool>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;
    public DeleteRoleByIdRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store)
    {
        _roleRepository = roleRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteRoleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var role = _roleRepository.GetById(request.Id);
            var result = _roleRepository.DeleteOne(role) == 1;
            if (result)
                _store.Add<RoleDomainEvent, string>(new RoleDomainEvent()
                    { Role = role, EventType = "DELETE" });
            return result;
        });
        //<-- END CUSTOM CODE-->
    }
}
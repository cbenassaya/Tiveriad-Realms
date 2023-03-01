using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Repositories;
using Tiveriad.Realms.Core.Entities;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;
public class DeleteModuleByIdRequestHandler : IRequestHandler<DeleteModuleByIdRequest, bool>
{
    private readonly IRepository<Module, string> _moduleRepository;
    private readonly IDomainEventStore _store;
    public DeleteModuleByIdRequestHandler(IRepository<Module, string> moduleRepository,IDomainEventStore store)
    {
        _store = store;
        _moduleRepository = moduleRepository;
    }

    public Task<bool> Handle(DeleteModuleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var feature = _moduleRepository.GetById(request.Id);
            var result = _moduleRepository.DeleteOne(feature) == 1;
            if (result)
                _store.Add<ModuleDomainEvent, string>(new ModuleDomainEvent()
                    { Module = feature, EventType = "DELETE" });
            return result;
        });
    //<-- END CUSTOM CODE-->
    }
}
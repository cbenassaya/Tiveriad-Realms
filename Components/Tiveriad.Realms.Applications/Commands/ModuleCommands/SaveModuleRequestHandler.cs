using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Realms.Core.DomainEvents;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;
public class SaveModuleRequestHandler : IRequestHandler<SaveModuleRequest, Module>
{
    private readonly IRepository<Module, string> _moduleRepository;
    private readonly IDomainEventStore _store;
    public SaveModuleRequestHandler(IRepository<Module, string> moduleRepository, IDomainEventStore store)
    {
        _moduleRepository = moduleRepository;
        _store = store;
    }

    public Task<Module> Handle(SaveModuleRequest request, CancellationToken cancellationToken)
    {
        var query = _moduleRepository.Queryable.Where(x => x.Id == request.Module.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _moduleRepository.AddOneAsync(request.Module, cancellationToken);
            _store.Add<ModuleDomainEvent,string>( new ModuleDomainEvent() {Module = request.Module, EventType = "INSERT"});
            return request.Module;
        //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
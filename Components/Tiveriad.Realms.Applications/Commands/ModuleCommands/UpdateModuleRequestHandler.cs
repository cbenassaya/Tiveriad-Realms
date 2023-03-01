using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;
public class UpdateModuleRequestHandler : IRequestHandler<UpdateModuleRequest, Module>
{
    private readonly IRepository<Module, string> _moduleRepository;
    public UpdateModuleRequestHandler(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task<Module> Handle(UpdateModuleRequest request, CancellationToken cancellationToken)
    {
        var query = _moduleRepository.Queryable.Where(x => x.Id == request.Module.Id);
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
                result.Key = request.Module.Key;
                result.Name = request.Module.Name;
                result.Description = request.Module.Description;
                result.State = request.Module.State;
                return result;
            }
        //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}
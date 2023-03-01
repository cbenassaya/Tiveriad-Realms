using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Repositories;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;
public class GetModuleByIdRequestHandler : IRequestHandler<GetModuleByIdRequest, Module>
{
    private readonly IRepository<Module, string> _moduleRepository;
    public GetModuleByIdRequestHandler(IRepository<Module, string> moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task<Module> Handle(GetModuleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _moduleRepository.Queryable.Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}
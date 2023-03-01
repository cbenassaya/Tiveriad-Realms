using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;

public record GetAllModulesRequest() : IRequest<IEnumerable<Module>>;
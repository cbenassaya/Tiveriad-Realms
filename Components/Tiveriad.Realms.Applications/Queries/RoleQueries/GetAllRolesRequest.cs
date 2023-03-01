using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.RoleQueries;

public record GetAllRolesRequest(string ModuleId) : IRequest<IEnumerable<Role>>;
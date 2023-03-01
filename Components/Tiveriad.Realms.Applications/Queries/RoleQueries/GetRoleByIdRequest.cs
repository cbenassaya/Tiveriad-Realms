using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.RoleQueries;

public record GetRoleByIdRequest(string Id, string ModuleId) : IRequest<Role>;
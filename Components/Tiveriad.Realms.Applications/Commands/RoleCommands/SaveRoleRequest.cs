using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;

public record SaveRoleRequest(Role Role, string ModuleId) : IRequest<Role>;
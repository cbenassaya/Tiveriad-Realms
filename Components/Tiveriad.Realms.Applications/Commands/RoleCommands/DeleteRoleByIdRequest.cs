using MediatR;

namespace Tiveriad.Realms.Applications.Commands.RoleCommands;

public record DeleteRoleByIdRequest(string Id, string ModuleId) : IRequest<bool>;
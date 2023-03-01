using MediatR;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;

public record DeleteModuleByIdRequest(string Id) : IRequest<bool>;
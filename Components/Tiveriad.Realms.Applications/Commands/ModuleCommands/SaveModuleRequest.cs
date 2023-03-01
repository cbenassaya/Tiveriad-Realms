using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Commands.ModuleCommands;

public record SaveModuleRequest(Module Module) : IRequest<Module>;
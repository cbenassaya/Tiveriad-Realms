using MediatR;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;

public record DeleteFeatureByIdRequest(string Id, string ModuleId) : IRequest<bool>;
using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;

public record UpdateFeatureRequest(Feature Feature, string ModuleId) : IRequest<Feature>;
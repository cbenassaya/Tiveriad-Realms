using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Commands.FeatureCommands;

public record SaveFeatureRequest(Feature Feature, string ModuleId) : IRequest<Feature>;
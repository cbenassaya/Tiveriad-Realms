using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;

public record GetAllFeaturesRequest(string ModuleId) : IRequest<IEnumerable<Feature>>;
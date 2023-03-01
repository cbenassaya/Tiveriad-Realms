using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.FeatureQueries;

public record GetFeatureByIdRequest(string Id,string ModuleId) : IRequest<Feature>;
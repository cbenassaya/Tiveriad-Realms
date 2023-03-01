using MediatR;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Applications.Queries.ModuleQueries;

public record GetModuleByIdRequest(string Id) : IRequest<Module>;
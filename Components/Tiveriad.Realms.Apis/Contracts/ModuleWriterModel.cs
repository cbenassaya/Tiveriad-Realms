using System;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.Contracts;
public class ModuleWriterModel
{
    public string? Id { get; set; }

    public string? Key { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
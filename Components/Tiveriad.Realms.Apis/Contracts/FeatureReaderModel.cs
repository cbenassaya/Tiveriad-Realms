using System;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.Contracts;
public class FeatureReaderModel
{
    public string? Id { get; set; }

    public string? Key { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public ModuleReduceModel? Module { get; set; }
}
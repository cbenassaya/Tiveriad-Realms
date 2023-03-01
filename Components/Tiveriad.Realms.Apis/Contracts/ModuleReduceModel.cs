using System;
using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Realms.Apis.Contracts;
public class ModuleReduceModel
{
    [MaxLength(24)]
    public string Id { get; set; }

    [MaxLength(6)]
    public string Key { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}
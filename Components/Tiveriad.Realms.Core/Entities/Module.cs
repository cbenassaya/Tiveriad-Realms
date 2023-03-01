using Tiveriad.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Realms.Core.Entities;
public class Module : IEntity<string>, IAuditable<string>
{
    [MaxLength(24)]
    public string Id { get; set; }

    [MaxLength(6)]
    public string Key { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public ModuleState? State { get; set; }

    public string CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
}
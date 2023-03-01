using Microsoft.EntityFrameworkCore;
using Tiveriad.Realms.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiveriad.Realms.Persistence.Entities;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("T_Role");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_RoleId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Module);
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (ModuleState)Enum.Parse(typeof(ModuleState), v));
    // <-- Object -->
    }
}
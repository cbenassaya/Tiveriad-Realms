using Microsoft.EntityFrameworkCore;
using Tiveriad.Realms.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiveriad.Realms.Persistence.Entities;
public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.ToTable("T_Module");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_ModuleId");
        // <-- ManyToOne -->
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (ModuleState)Enum.Parse(typeof(ModuleState), v));
    // <-- Object -->
    }
}
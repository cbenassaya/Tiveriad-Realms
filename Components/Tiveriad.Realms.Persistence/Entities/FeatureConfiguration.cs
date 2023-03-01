using Microsoft.EntityFrameworkCore;
using Tiveriad.Realms.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiveriad.Realms.Persistence.Entities;
public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable("T_Feature");
        // <-- Id -->
        builder.HasKey(b => b.Id).HasName("PK_FeatureId");
        // <-- ManyToOne -->
        builder.HasOne(b => b.Module);
        // <-- OneToMany -->
        // <-- Enum -->
        builder.Property(e => e.State).HasConversion(v => v.ToString(), v => (ModuleState)Enum.Parse(typeof(ModuleState), v));
    // <-- Object -->
    }
}
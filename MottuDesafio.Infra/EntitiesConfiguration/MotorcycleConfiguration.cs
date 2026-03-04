using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuDesafio.Domain.Entities;

namespace MottuDesafio.InfraData.EntitiesConfiguration;

public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Model);
        builder.HasIndex(x => x.Plate).IsUnique();
    }
}

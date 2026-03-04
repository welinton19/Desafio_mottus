using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuDesafio.Domain.Entities;

namespace MottuDesafio.InfraData.EntitiesConfiguration;

public class DeliveryMenConfiguration : IEntityTypeConfiguration<DeliveryMen>
{
    public void Configure(EntityTypeBuilder<DeliveryMen> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(x => x.Cnpj)
            .IsUnique();
        builder.HasIndex(x => x.CnhNumber)
            .IsUnique();
        builder.Property(x => x.CnhType);

        builder.HasOne(x => x.User)
        .WithOne()
        .HasForeignKey<DeliveryMen>(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}

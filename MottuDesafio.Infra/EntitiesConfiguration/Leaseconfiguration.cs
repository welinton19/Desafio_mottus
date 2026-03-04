using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MottuDesafio.Domain.Entities;

namespace MottuDesafio.InfraData.EntitiesConfiguration;

public class Leaseconfiguration : IEntityTypeConfiguration<Lease>
{
    public void Configure(EntityTypeBuilder<Lease> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Plans);

        builder.HasOne(x => x.DeliveryMen);
        builder.HasOne(x => x.Motorcycle);
    }
}

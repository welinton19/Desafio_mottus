using Microsoft.EntityFrameworkCore;
using MottuDesafio.Domain.Entities;

namespace MottuDesafio.InfraData.Data;

public class MottusDbContext : DbContext
{
    public MottusDbContext(DbContextOptions<MottusDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Motorcycle> Motorcycle { get; set; }
    public DbSet<DeliveryMen> DeliveryMen { get; set; }
    public DbSet<Lease> Lease { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MottusDbContext).Assembly);
    }
}

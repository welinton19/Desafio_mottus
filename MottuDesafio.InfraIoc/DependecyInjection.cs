using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MottuDesafio.Domain.Interface;
using MottuDesafio.InfraData.Data;
using MottuDesafio.InfraData.Repositories;

namespace MottuDesafio.InfraIoc;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MottusDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MotoConnection"),
                (b => b.MigrationsAssembly(typeof(MottusDbContext).Assembly.FullName)));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<ILeaseRepository, LeaseRepository>();
        services.AddScoped<IDeliveryMenRepository, DeliveryMenRepository>();
       
        return services;
    }
}

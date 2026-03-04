using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Domain.Interface;

public interface IMotorcycleRepository
{
    Task<Motorcycle> CreateAsync(Motorcycle motorcycle);
    Task<List<Motorcycle>> GetAllAsync();
    Task<Motorcycle?> GetByIdAsync(int id);
    Task<Motorcycle> UpdateAsync(Motorcycle motorcycle);
    Task<Motorcycle> DeleteAsync(int id);
}

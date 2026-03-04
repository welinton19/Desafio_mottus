using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Domain.Interface;

public interface ILeaseRepository
{
    Task<Lease> CreateAsync(Lease lease);
    Task<Lease> GetLeaseAsync(int id);
    Task<List<Lease>> GetAllAsync();
    Task<Lease> UpdateAsync(Lease lease);
    Task<Lease> DeleteAsync(int id);
}

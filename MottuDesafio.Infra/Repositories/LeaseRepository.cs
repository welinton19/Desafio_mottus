using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;
using MottuDesafio.InfraData.Data;

namespace MottuDesafio.InfraData.Repositories;

public class LeaseRepository : ILeaseRepository
{
    private readonly MottusDbContext _context;

    public LeaseRepository(MottusDbContext context)
    {
        _context = context;
    }

    public async Task<Lease> CreateAsync(Lease lease)
    {
        await _context.Lease.AddAsync(lease);
        await _context.SaveChangesAsync();
        return lease;
    }

    public  Task<Lease> DeleteAsync(int id)
    {
         _context.Remove(id);
        _context.SaveChanges();
        return Task.FromResult(_context.Lease.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<Lease>> GetAllAsync()
    {
        _context.Lease.ToList();
        return Task.FromResult(_context.Lease.ToList());
    }

    public Task<Lease> GetLeaseAsync(int id)
    {
        _context.Lease.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(_context.Lease.FirstOrDefault(x => x.Id == id));
    }

    public Task<Lease> UpdateAsync(Lease lease)
    {
        _context.Lease.Update(lease);
        _context.SaveChanges();
        return Task.FromResult(lease);
    }
}

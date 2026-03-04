using Microsoft.EntityFrameworkCore;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;
using MottuDesafio.InfraData.Data;

namespace MottuDesafio.InfraData.Repositories;

public class MotorcycleRepository : IMotorcycleRepository
{

    private readonly MottusDbContext _context;

    public MotorcycleRepository(MottusDbContext context)
    {
        _context = context;
    }

    public async Task<Motorcycle> CreateAsync(Motorcycle motorcycle)
    {
        await _context.Motorcycle.AddAsync(motorcycle);
        await _context.SaveChangesAsync();
        return motorcycle;
    }

    public async Task<Motorcycle> DeleteAsync(int id)
    {
        var motorcycle = await _context.Motorcycle.FirstOrDefaultAsync(x => x.Id == id);
        _context.Motorcycle.Remove(motorcycle!);
        _context.SaveChanges();
        return motorcycle is null ? new Motorcycle() : motorcycle;
    }

    public async Task<List<Motorcycle>> GetAllAsync()
    {
        return await _context.Motorcycle.ToListAsync();
    }

    public async Task<Motorcycle?> GetByIdAsync(int id)
    {
        return await _context.Motorcycle
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Motorcycle> UpdateAsync(Motorcycle motorcycle)
    {
        _context.Motorcycle.Update(motorcycle);
        await _context.SaveChangesAsync();
        return motorcycle;
    }

    


}

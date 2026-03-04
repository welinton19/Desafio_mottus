using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;
using MottuDesafio.InfraData.Data;

namespace MottuDesafio.InfraData.Repositories;

public class DeliveryMenRepository : IDeliveryMenRepository
{
    private readonly MottusDbContext _context;

    public DeliveryMenRepository(MottusDbContext context)
    {
        _context = context;
    }

    public Task<DeliveryMen> CreateDeliveryMenAsync(DeliveryMen deliveryMen)
    {
        _context.DeliveryMen.Add(deliveryMen);
        _context.SaveChangesAsync();
        return Task.FromResult(deliveryMen);
    }

    public Task<DeliveryMen> DeleteDeliveryMenAsync(int id)
    {
        _context.Remove(id);
        _context.SaveChangesAsync();
        return Task.FromResult(_context.DeliveryMen.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<DeliveryMen>> GetAllAsync()
    {
        _context.DeliveryMen.ToList();
        return Task.FromResult(_context.DeliveryMen.ToList());
    }

    public Task<DeliveryMen> GetByIdAsync(int id)
    {
        _context.DeliveryMen.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(_context.DeliveryMen.FirstOrDefault(x=>x.Id == id));
    }

    public Task<DeliveryMen> UpdateDeliveryMenAsync(DeliveryMen deliveryMen)
    {
        _context.DeliveryMen.Update(deliveryMen);
        _context.SaveChanges();
        return Task.FromResult(deliveryMen);
    }
}

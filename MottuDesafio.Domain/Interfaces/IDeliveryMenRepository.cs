using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Domain.Interface;

public interface IDeliveryMenRepository
{
    Task<DeliveryMen> CreateDeliveryMenAsync(DeliveryMen deliveryMen);
    Task<List<DeliveryMen>> GetAllAsync();
    Task<DeliveryMen> GetByIdAsync(int id);
    Task<DeliveryMen> UpdateDeliveryMenAsync(DeliveryMen deliveryMen);
    Task<DeliveryMen> DeleteDeliveryMenAsync(int id);
}

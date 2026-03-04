using MottuDesafio.Application.DTOs;

namespace MottuDesafio.Application.Interfaces;

public interface IDeliveryMenService
{
    Task<DeliveryMenGetDTO> CreateDeliveryMenAsync(CreateDeliveryMenDTO deliveryMen);
    Task<List<DeliveryMenGetDTO>> GetAllDeliveryMenAsync();
    Task<DeliveryMenGetDTO> GetDeliveryMenByIdAsync(int id);
    Task<DeliveryMenGetDTO> UpdateDeliveryMenAsync(UpdateDeliveryMenDTO deliveryMen);
    Task<DeliveryMenGetDTO> DeleteDeliveryMenAsync(int id);
}

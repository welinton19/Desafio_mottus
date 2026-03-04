using MottuDesafio.Application.DTOs;


namespace MottuDesafio.Application.Interfaces;

public interface IMotorcyclerService
{
    Task<MotorCycleGetDTO> CreateMotorcyclerAsync(CreateMotorcycleDTO motorcycle);
    Task<MotorCycleGetDTO> GetMotorcyclerByIdAsync(int id);
    Task<List<MotorCycleGetDTO>> GetAllMotorcyclersAsync();
    Task<MotorCycleGetDTO> UpdateMotorcyclerAsyn(UpdateMotorcycleDTO upMotorcycle);
    Task<MotorCycleGetDTO> DeletMotorcyclerAsync(int id);
}

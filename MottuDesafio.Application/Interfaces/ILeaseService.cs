using MottuDesafio.Application.DTOs;

namespace MottuDesafio.Application.Interfaces;

public interface ILeaseService
{
    Task<LeaseGetDTO> CreateLeaseAsync(CreateLeaseDTO lease);
    Task<LeaseGetDTO> GetLeaseByIdAsync(int id);
    Task<List<LeaseGetDTO>> GetAllAsync();
    Task<LeaseGetDTO> UpdateLeaseAsync(UpdateLeaseDTO upLease);
    Task<LeaseGetDTO> DeleteLeaseAsync(int id);
}

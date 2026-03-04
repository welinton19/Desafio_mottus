using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;

namespace MottuDesafio.Application.Services;

public class LeaseService : ILeaseService
{
    private readonly ILeaseRepository _leaseRepository;
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly IDeliveryMenRepository _deliveryRepository;

    public LeaseService(
        ILeaseRepository leaseRepository,
        IMotorcycleRepository motorcycleRepository,
        IDeliveryMenRepository deliveryRepository)
    {
        _leaseRepository = leaseRepository;
        _motorcycleRepository = motorcycleRepository;
        _deliveryRepository = deliveryRepository;
    }

    public async Task<Lease> CreateAsync(CreateLeaseDTO dto)
    {
        if (await _motorcycleRepository.GetByIdAsync(dto.MotorcycleId) == null)
            throw new Exception("Moto não encontrada");

        if (await _deliveryRepository.GetByIdAsync(dto.DeliveryMenId) == null)
            throw new Exception("Entregador não encontrado");

        var lease = new Lease
        {
            MotorcycleId = dto.MotorcycleId,
            DeliveryMenId = dto.DeliveryMenId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            ExpectedEndDate = dto.ExpectedEndDate,
            Plans = dto.Plans
        };

        await _leaseRepository.CreateAsync(lease);

        return lease;
    }

    public async Task<LeaseGetDTO> CreateLeaseAsync(CreateLeaseDTO lease)
    {
        var leaseEntity = new Domain.Entities.Lease
        {
            MotorcycleId = lease.MotorcycleId,
            DeliveryMenId = lease.DeliveryMenId,
            StartDate = lease.StartDate,
            EndDate = lease.EndDate,
            ExpectedEndDate = lease.ExpectedEndDate,
            Plans = lease.Plans
        };
        var createdLease = await _leaseRepository.CreateAsync(leaseEntity);
        return new LeaseGetDTO
        {
            Id = createdLease.Id,
            StartDate = createdLease.StartDate,
            EndDate = createdLease.EndDate
        };

    }

    public async Task<LeaseGetDTO> DeleteLeaseAsync(int id)
    {

        var deletedLease = await _leaseRepository.DeleteAsync(id);
        if (deletedLease == null)
            return null;
        return new LeaseGetDTO
        {
            Id = deletedLease.Id,
            StartDate = deletedLease.StartDate,
            EndDate = deletedLease.EndDate
        };
    }

    public async Task<List<LeaseGetDTO>> GetAllAsync()
    {
        var list = await _leaseRepository.GetAllAsync();
        var leases = new List<LeaseGetDTO>();
        foreach (var lease in list)
        {
            leases.Add(new LeaseGetDTO
            {
                Id = lease.Id,
                StartDate = lease.StartDate,
                EndDate = lease.EndDate
            });
        }
        return leases;
    }

    public async Task<LeaseGetDTO> GetLeaseByIdAsync(int id)
    {
        var lease = await _leaseRepository.GetLeaseAsync(id);
        if (lease == null)
            return null;
        return new LeaseGetDTO
        {
            Id = lease.Id,
            StartDate = lease.StartDate,
            EndDate = lease.EndDate
        };
    }

    public async Task<LeaseGetDTO> UpdateLeaseAsync(UpdateLeaseDTO upLease)
    {
        var leaseEntity = new Domain.Entities.Lease
        {

            StartDate = upLease.StartDate,
            EndDate = upLease.EndDate
        };
        var updatedLease = await _leaseRepository.UpdateAsync(leaseEntity);
        if (updatedLease == null)
            return null;
        return new LeaseGetDTO
        {
            Id = updatedLease.Id,
            StartDate = updatedLease.StartDate,
            EndDate = updatedLease.EndDate
        };

    }
}

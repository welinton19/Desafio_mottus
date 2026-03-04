using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;

namespace MottuDesafio.Application.Services;

public class DeliveryMenService : IDeliveryMenService
{
    private readonly IDeliveryMenRepository _deliveryMenRepository;


    public DeliveryMenService(IDeliveryMenRepository deliveryMenRepository)
    {
        _deliveryMenRepository = deliveryMenRepository;

    }

    public async Task<DeliveryMenGetDTO> CreateDeliveryMenAsync(CreateDeliveryMenDTO deliveryMen)
    {
        var deliveryMenEntity = new DeliveryMen
        {
            UserId = deliveryMen.UserId,
            Name = deliveryMen.Name,
            DateOfBirth = deliveryMen.DateOfBirth,
            Cnpj = deliveryMen.Cnpj,
            CnhNumber = deliveryMen.CnhNumber,
            CnhType = deliveryMen.CnhType,
            CnhImagePath = deliveryMen.CnhImagePath
        };
        var createdDeliveryMen = await _deliveryMenRepository.CreateDeliveryMenAsync(deliveryMenEntity);
        return new DeliveryMenGetDTO
        {
            Id = createdDeliveryMen.Id,
            UserId = createdDeliveryMen.UserId,
            Name = deliveryMen.Name,
            DateOfBirth = deliveryMen.DateOfBirth,
            Cnpj = deliveryMen.Cnpj,
            CnhNumber = deliveryMen.CnhNumber,
            CnhType = deliveryMen.CnhType,
            CnhImagePath = deliveryMen.CnhImagePath
        };
    }


    public async Task<DeliveryMenGetDTO> DeleteDeliveryMenAsync(int id)
    {
        var deletedDeliveryMen = await _deliveryMenRepository.DeleteDeliveryMenAsync(id);
        if (deletedDeliveryMen == null)
            return null;
        return new DeliveryMenGetDTO
        {
            Id = deletedDeliveryMen.Id,
            Name = deletedDeliveryMen.Name,
            DateOfBirth = deletedDeliveryMen.DateOfBirth
        };
    }

    public async Task<List<DeliveryMenGetDTO>> GetAllDeliveryMenAsync()
    {
        var deliveryMenList = await _deliveryMenRepository.GetAllAsync();
        var deliveryMenGetDTOList = new List<DeliveryMenGetDTO>();
        foreach (var deliveryMen in deliveryMenList)
        {
            deliveryMenGetDTOList.Add(new DeliveryMenGetDTO
            {
                Id = deliveryMen.Id,
                Name = deliveryMen.Name,
                DateOfBirth = deliveryMen.DateOfBirth
            });
        }
        return deliveryMenGetDTOList;
    }

    public async Task<DeliveryMenGetDTO> GetDeliveryMenByIdAsync(int id)
    {
        var deliveryMen = await _deliveryMenRepository.GetByIdAsync(id);
        if (deliveryMen == null)
            return null;
        return new DeliveryMenGetDTO
        {
            Id = deliveryMen.Id,
            Name = deliveryMen.Name,
            DateOfBirth = deliveryMen.DateOfBirth
        };
    }

    public async Task<DeliveryMenGetDTO> UpdateDeliveryMenAsync(UpdateDeliveryMenDTO deliveryMen)
    {
        var deliveryMenEntity = new DeliveryMen
        {

            Cnpj = deliveryMen.Cnpj,

        };
        var updatedDeliveryMen = await _deliveryMenRepository.UpdateDeliveryMenAsync(deliveryMenEntity);
        if (updatedDeliveryMen == null)
            return null;
        return new DeliveryMenGetDTO
        {
            Id = updatedDeliveryMen.Id,

            Cnpj = deliveryMen.Cnpj,

        };
    }
}

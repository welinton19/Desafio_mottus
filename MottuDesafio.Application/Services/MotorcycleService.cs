using AutoMapper;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;

namespace MottuDesafio.Application.Services;

public class MotorcycleService : IMotorcyclerService
{
    private readonly IMotorcycleRepository _motorcycleRepository;


    public MotorcycleService(IMotorcycleRepository motorcycleRepository)
    {
        _motorcycleRepository = motorcycleRepository;

    }

    

    public async Task<MotorCycleGetDTO> CreateMotorcyclerAsync(CreateMotorcycleDTO motorcycle)
    {
        var createdMotorcycle = new Motorcycle
        {

            Model = motorcycle.Model,
            Year = motorcycle.Yaer,
            Plate = motorcycle.Plate
        };
        var result = await _motorcycleRepository.CreateAsync(createdMotorcycle);
        return new MotorCycleGetDTO
        {
            Id = result.Id,
            Model = result.Model,
            Year = result.Year,
            Plate = result.Plate
        };
    }

    public async Task<MotorCycleGetDTO> DeletMotorcyclerAsync(int id)
    {
        var deletMotorcycle = await _motorcycleRepository.DeleteAsync(id);
        if(deletMotorcycle == null)
            return null;
        return new MotorCycleGetDTO
        {
            Id = deletMotorcycle.Id,
            Model = deletMotorcycle.Model,
            Year = deletMotorcycle.Year,
            Plate = deletMotorcycle.Plate
        };
    }

    public async Task<List<MotorCycleGetDTO>> GetAllMotorcyclersAsync()
    {
        var motorcyclers = await _motorcycleRepository.GetAllAsync();
        var result = new List<MotorCycleGetDTO>();
        foreach(var motorcycle in motorcyclers)
        {
            result.Add(new MotorCycleGetDTO
            {
                Id = motorcycle.Id,
                Model = motorcycle.Model,
                Year = motorcycle.Year,
                Plate = motorcycle.Plate
            });
        }
        return result;
    }

    public async Task<MotorCycleGetDTO> GetMotorcyclerByIdAsync(int id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        if(motorcycle == null)
            return null;
        return new MotorCycleGetDTO
        {
            Id = motorcycle.Id,
            Model = motorcycle.Model,
            Year = motorcycle.Year,
            Plate = motorcycle.Plate
        };
    }

    public async Task<MotorCycleGetDTO> UpdateMotorcyclerAsyn(UpdateMotorcycleDTO upMotorcycle)
    {
        var motorcycle = new Motorcycle
        {
            
            Plate = upMotorcycle.Plate
        };
        var result = await _motorcycleRepository.UpdateAsync(motorcycle);
        if(result == null)
            return null;
        return new MotorCycleGetDTO
        {
            Id = result.Id,
            Model = result.Model,
            Year = result.Year,
            Plate = result.Plate
        };
    }
}

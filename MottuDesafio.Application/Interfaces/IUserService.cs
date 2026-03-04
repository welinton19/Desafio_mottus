using MottuDesafio.Application.DTOs;
using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Application.Interfaces;

public interface IUserService
{
    Task<CreateUserDTO> CreateUserAsync(CreateUserDTO user);
    Task<User?> ValidateUserLogin(string name, string password);
}

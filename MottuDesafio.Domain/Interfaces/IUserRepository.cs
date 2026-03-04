using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Domain.Interface;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByNameAsync(string name);
}

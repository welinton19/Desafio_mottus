using MottuDesafio.Domain.Entities;

namespace MottuDesafio.Application.Interfaces;

public interface ITokenService
{
    string GenereteUserToken(User user);
}

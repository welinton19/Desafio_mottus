using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Application.DTOs;

public class CreateUserDTO
{
    
    public string Name { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

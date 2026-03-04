using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;

namespace MottuDesafio.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    private readonly ILogger<UserService> _logger;
    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

    public UserService(IUserRepository userRepository,  ILogger<UserService> logger, PasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        
        _logger = logger;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserDTO> CreateUserAsync(CreateUserDTO user)
    {
        
        var salt = Guid.NewGuid().ToByteArray(); 
        var passwordWithSalt = user.Password + Convert.ToBase64String(salt);

        
        var hashedPassword = _passwordHasher.HashPassword(null, passwordWithSalt);

        var newUser = new User
        {
            Name = user.Name,
            Role = user.Role,
            PasswordSalt = salt,
            PasswordHash = hashedPassword != null ? Convert.FromBase64String(hashedPassword) : Array.Empty<byte>()
        };

        await _userRepository.CreateAsync(newUser);
        return user;
    }

    public async Task<User?> ValidateUserLogin(string name, string password)
    {
        var user = await _userRepository.GetByNameAsync(name);

        if (user == null)
            return null;

        var hashedString = Convert.ToBase64String(user.PasswordHash);
        var salt = Convert.ToBase64String(user.PasswordSalt);
        var passwordWithSalt = password + salt;

        var result = _passwordHasher.VerifyHashedPassword(user, hashedString, passwordWithSalt);

        if (result != PasswordVerificationResult.Success)
            return null;

        return user;
    }
    public bool VerifyPassword(User user, string password)
    {
        
        var salt = Convert.ToBase64String(user.PasswordSalt);

        
        var passwordWithSalt = password + salt;

        
        var storedHashString = Convert.ToBase64String(user.PasswordHash);

        
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, storedHashString, passwordWithSalt);

        return result == PasswordVerificationResult.Success;
    }
}


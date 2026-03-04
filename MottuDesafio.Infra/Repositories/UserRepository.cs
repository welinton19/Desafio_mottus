using Microsoft.EntityFrameworkCore;
using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Interface;
using MottuDesafio.InfraData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuDesafio.InfraData.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MottusDbContext _context;

    public UserRepository(MottusDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
       _context.Add(user);
        _context.SaveChanges();
        return  user;
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Name == name);
    }
}

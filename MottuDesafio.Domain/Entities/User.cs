using MottuDesafio.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuDesafio.Domain.Entities;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "O campo Password é Obrigatório.")]
    [MaxLength(8)]
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }    
    
    public UserRole Role { get; set; }

    public User () { }

    public User(string name, byte[] passwordHash, byte[] passwordSalt, UserRole role) 
    {
        Name = name;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Role = role;

    }
}

using Microsoft.AspNetCore.Authorization;

namespace MottuDesafio.InfraData.Authentication;

public class RoleRequeriment : IAuthorizationRequirement
{
    public string Role { get; }
    public RoleRequeriment(string role)
    {
        Role = role;
    }
}

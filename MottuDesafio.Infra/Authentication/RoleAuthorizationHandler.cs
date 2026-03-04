using Microsoft.AspNetCore.Authorization;

namespace MottuDesafio.InfraData.Authentication;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequeriment>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequeriment requirement)
    {
        if (context.User.IsInRole(requirement.Role))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}

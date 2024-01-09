using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Authorization
{
    public class AdminOrOwnerRequirement : IAuthorizationRequirement
    {
        public AdminOrOwnerRequirement()
        { }
    }

    public class AdminOrOwnerHandler : AuthorizationHandler<AdminOrOwnerRequirement, OwnerContainer>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminOrOwnerRequirement requirement, OwnerContainer resource)
        {
            /* Console.WriteLine("Runnign authorization check =============");
            var claims = context.User;
            var userRole = claims.FindFirst(c => c.Type == ClaimTypes.Role)!.Value;
            var userId = claims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value; // id of logged in user

            if (userRole == Role.Admin.ToString())
            {
                context.Succeed(requirement);
            }
            else if (userId == resource.User.Id.ToString())
            {
                context.Succeed(requirement);
            } */
            Console.WriteLine("Running authorization check =============");
            Console.WriteLine($"user id: {resource.UserId}");
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

}


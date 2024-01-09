using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Authorization
{
    public class CheckAddressRequirement(int maxLength) : IAuthorizationRequirement
    {
        public int MaxLength { get; set; } = maxLength;
    }

    public class CheckAddressHandler : AuthorizationHandler<CheckAddressRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CheckAddressRequirement requirement)
        {
            Console.WriteLine("adress checker run =====");
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
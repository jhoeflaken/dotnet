

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using UserManagementApi.Models;

namespace UserManagementApi.Authorization
{
    public class UserRoleAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, UserRole>
    {
        UserManager<IdentityUser> _userManager;
        
        public UserRoleAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                       OperationAuthorizationRequirement requirement, 
                                                       UserRole resource)
        {
            // If no User or Resource then requirements are not met.
            if (context.User == null || resource == null) 
            {
                return Task.CompletedTask;
            }

            // If we are not creating or updating or deleting a UserRole the requirements are not met.
            if (requirement.Name != Constants.OpCreateUserRole && 
                requirement.Name != Constants.OpUpdateUserRole &&
                requirement.Name != Constants.OpDeleteUserRole)
            {
                return Task.CompletedTask;
            }

            // TODO See if the user has Admin role for the specified UserRole.

            // Requirements are not met.
            return Task.CompletedTask;
        }
    }
}
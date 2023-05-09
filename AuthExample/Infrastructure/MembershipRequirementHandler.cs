using AuthExample.Data;
using AuthExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AuthExample.Infrastructure
{
    public class MembershipRequirementHandler : AuthorizationHandler<HasMembershipRequirement>
    {
        private UserManager<AppUser> _userManager;

        public MembershipRequirementHandler(UserManager<AppUser> usrMgr)
        {
            _userManager = usrMgr;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasMembershipRequirement requirement)
        {
            // is the membership level <= MembershipRequirement?
            // succeed

            var project = context.Resource as Project;
            var user = _userManager.GetUserId(context.User);

            bool isMember = false;

            if (project != null)
            {
                // does our user exist in the memberships
                // and are they of the right level
                isMember = project.Memberships.Any(m => m.UserId == user && m.Level <= requirement.Level);
            }

            if (isMember)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;

namespace AuthExample.Infrastructure
{
    public class HasMembershipRequirement : IAuthorizationRequirement
    {
        public int Level { get; }

        public HasMembershipRequirement(int membershipLevel)
        {
            Level = membershipLevel;
        }
    }
}

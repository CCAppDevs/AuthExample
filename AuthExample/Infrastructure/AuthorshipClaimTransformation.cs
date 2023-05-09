using AuthExample.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthExample.Infrastructure
{
    public class AuthorshipClaimTransformation : IClaimsTransformation
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        // constructor so that we can inject a context
        public AuthorshipClaimTransformation(ApplicationDbContext ctx, UserManager<AppUser> usr)
        {
            _context = ctx;
            _userManager = usr;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            var claimType = "OwnedProject";
            if (!principal.HasClaim(claim => claim.Type == claimType))
            {
                var userId = _userManager.GetUserId(principal);
                // get access to the database, compile a list of owned ids and append to the claim
                var projectIds = _context.Memberships
                    .Where(m => m.UserId == userId && m.Level == 0)
                    .Select(m => m.ProjectId);

                foreach (var id in projectIds)
                {
                    claimsIdentity.AddClaim(new Claim(claimType, id.ToString()));
                }
            }

            principal.AddIdentity(claimsIdentity);
            return Task.FromResult(principal);
        }
    }
}

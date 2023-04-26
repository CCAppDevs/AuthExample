using AuthExample.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthExample.Data
{
    public class AppUser : IdentityUser
    {
        public string FavoriteColor { get; set; }

        // navigation property
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Membership> Memberships { get; set; }
    }
}

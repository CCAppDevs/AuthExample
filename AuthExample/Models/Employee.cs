using AuthExample.Data;
using Microsoft.AspNetCore.Identity;

namespace AuthExample.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // navigation properties
        public string ManagerId { get; set; }
        public virtual AppUser Manager { get; set; }
    }
}

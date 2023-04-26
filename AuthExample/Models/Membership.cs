using AuthExample.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthExample.Models
{
    public class Membership
    {
        public int Id { get; set; }
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int Level { get; set; }
    }
}

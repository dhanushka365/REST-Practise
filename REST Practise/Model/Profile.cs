using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Profile :IdentityUser<Guid>
    {
        
        public  Guid RoleId { get; set; }

        public Guid EmployeeId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}

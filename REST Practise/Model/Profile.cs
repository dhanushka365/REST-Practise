using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }

        public int EmployeeId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}

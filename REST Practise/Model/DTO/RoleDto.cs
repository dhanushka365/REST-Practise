using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model.DTO
{
    public class RoleDto
    {
        [Required]
        public  Guid Id { get; set; }

        [Required]
        public  string Name { get; set; }
    }
}

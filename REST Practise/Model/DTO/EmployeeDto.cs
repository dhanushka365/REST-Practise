using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model.DTO
{
    public class EmployeeDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BOD { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Position { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

    }
}

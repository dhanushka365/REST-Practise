using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model.DTO
{
    public class DepartmentDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        //public Employee Employee { get; set; }
    }
}

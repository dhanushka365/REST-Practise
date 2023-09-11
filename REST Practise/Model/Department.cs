using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Department
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }


    }
}

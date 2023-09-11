using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model.DTO
{
    public class SalaryDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double BasicSalary { get; set; }
        [Required]
        public double Bonus { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }

    }
}

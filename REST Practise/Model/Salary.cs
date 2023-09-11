using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Salary
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public double BasicSalary { get; set; }

        [Required]
        public double Bonus { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}

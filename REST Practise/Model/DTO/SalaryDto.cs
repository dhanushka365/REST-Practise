namespace REST_Practise.Model.DTO
{
    public class SalaryDto
    {
        public int Id { get; set; }

        public double BasicSalary { get; set; }

        public double Bonus { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}

﻿namespace REST_Practise.Model.DTO
{
    public class DeleteSalaryRequestDto
    {

        public double BasicSalary { get; set; }

        public double Bonus { get; set; }

        public Guid EmployeeId { get; set; }

        
    }
}

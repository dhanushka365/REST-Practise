using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BOD {  get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public string ProfileImage { get; set; } 

        public int DepartmentId { get; set; }

        public Department Department { get; set; }



    }
}

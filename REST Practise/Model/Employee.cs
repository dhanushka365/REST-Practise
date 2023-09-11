using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Employee
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BOD {  get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Position { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }



    }
}

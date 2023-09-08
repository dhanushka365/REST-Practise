using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }


    }
}

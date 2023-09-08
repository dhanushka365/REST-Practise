using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}

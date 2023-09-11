using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace REST_Practise.Model
{
    public class Role :IdentityRole<Guid>
    {
      
        [Required]
        public override Guid Id { get; set; }

        [Required]
        public override string Name { get; set; }

    }
}

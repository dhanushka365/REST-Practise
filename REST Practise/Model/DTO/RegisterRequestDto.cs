using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.Model.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{  get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public Guid Roles { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
    }
}

namespace REST_Practise.Model.DTO
{
    public class UpdateProfileRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public Guid EmployeeId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}

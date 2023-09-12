namespace REST_Practise.Model.DTO
{
    public class ProfileDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }

        public Guid EmployeeId { get; set; }

         
    }
}

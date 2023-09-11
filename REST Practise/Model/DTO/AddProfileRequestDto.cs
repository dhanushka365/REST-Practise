namespace REST_Practise.Model.DTO
{
    public class AddProfileRequestDto
    {
       
        public Guid RoleId { get; set; }

        public Guid EmployeeId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}

namespace REST_Practise.Model.DTO
{
    public class AddEmployeeRequestDto
    {
        public string Name { get; set; }

        public DateTime BOD { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }

        public string ProfileImage { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}

using REST_Practise.Model;
using REST_Practise.Model.DTO;


namespace REST_Practise.Mappings
{
    public class AutoMapperProfiles: AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<AddDepartmentRequestDto, Department>().ReverseMap();
            CreateMap<UpdateDepartmentRequestDto, Department>().ReverseMap();
            CreateMap<Employee,EmployeeDto >().ReverseMap();
            CreateMap<AddEmployeeRequestDto, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeRequestDto, Employee>().ReverseMap();
            CreateMap<Salary, SalaryDto>().ReverseMap();
            CreateMap<AddSalaryRequestDto, Salary>().ReverseMap();
            CreateMap<UpdateSalaryRequestDto, Salary>().ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<AddProfileRequestDto, Profile>().ReverseMap();
            CreateMap<UpdateProfileRequestDto, Profile>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

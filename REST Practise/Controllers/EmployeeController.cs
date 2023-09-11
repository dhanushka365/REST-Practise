using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;
using REST_Practise.Model;
using REST_Practise.Model.DTO;
using REST_Practise.Model.Repositories;

namespace REST_Practise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ERPContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;


        public EmployeeController(ERPContext dbContext, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Use Entity Framework Core to retrieve departments from the database
            var employees = await _dbContext.Employees.ToListAsync();

            // Use the department repository to retrieve additional department data
            var employeeDomainModels = await _employeeRepository.GetAllAsync();

            // Map the department data to DTOs using AutoMapper
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employeeDomainModels);

            // Combine the data from both sources if needed

            // Return the result as an OK response
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                // Use Entity Framework Core to retrieve a department by its ID
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(d => d.Id == id);

                if (employee == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok(employee); // Department found and returned
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeRequestDto addEmployeeRequestDto)
        {

            //Map DTO to domain model
            var employeeDomainModel = _mapper.Map<Employee>(addEmployeeRequestDto);

            //use Domain model to create difficulty 
            await _employeeRepository.CreateAsync(employeeDomainModel);

            //Map domain model into DTO
            return Ok(_mapper.Map<DepartmentDto>(employeeDomainModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeRequestDto updateEmployeeRequestDto)
        {
            // Check if a department with the given ID exists
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound(); // Department not found
            }

            // Map the DTO with updated data to the existing domain model
            _mapper.Map(updateEmployeeRequestDto, existingEmployee);

            // Use the repository to update the department
            var updatedEmployee = await _employeeRepository.UpdateAsync(existingEmployee);

            // Map the updated department to a DTO
            var updatedEmployeeDto = _mapper.Map<EmployeeDto>(updatedEmployee);

            return Ok(updatedEmployeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _employeeRepository.DeleteAsync(id);

                if (employee == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok("Employee Deleted Sucessfully"); // Department deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }



}

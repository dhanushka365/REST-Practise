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
    public class SalaryController : ControllerBase
    {
        private readonly ERPContext _dbContext;
        private readonly ISalaryRepository _salaryRepository;
        private readonly IMapper _mapper;


        public SalaryController(ERPContext dbContext, IMapper mapper, ISalaryRepository salaryRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _salaryRepository = salaryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Use Entity Framework Core to retrieve departments from the database
            var salary = await _dbContext.Salarys.ToListAsync();

            // Use the department repository to retrieve additional department data
            var salaryDomainModels = await _salaryRepository.GetAllAsync();

            // Map the department data to DTOs using AutoMapper
            var salaryDtos = _mapper.Map<List<SalaryDto>>(salaryDomainModels);

            // Combine the data from both sources if needed

            // Return the result as an OK response
            return Ok(salaryDtos); ;
        }

        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddSalaryRequestDto addSalaryRequestDto)
        {

            //Map DTO to domain model
            var salaryDomainModel = _mapper.Map<Salary>(addSalaryRequestDto);

            //use Domain model to create difficulty 
            await _salaryRepository.CreateAsync(salaryDomainModel);

            //Map domain model into DTO
            return Ok(_mapper.Map<SalaryDto>(salaryDomainModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalaryRequestDto updateSalaryRequestDto)
        {
            // Check if a department with the given ID exists
            var existingSalary = await _salaryRepository.GetByIdAsync(id);
            if (existingSalary == null)
            {
                return NotFound(); // Department not found
            }

            // Map the DTO with updated data to the existing domain model
            _mapper.Map(updateSalaryRequestDto, existingSalary);

            // Use the repository to update the department
            var updatedSalary = await _salaryRepository.UpdateAsync(existingSalary);

            // Map the updated department to a DTO
            var updatedSalaryDto = _mapper.Map<SalaryDto>(updatedSalary);

            return Ok(updatedSalaryDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Use Entity Framework Core to retrieve a department by its ID
                var salary = await _dbContext.Salarys.FirstOrDefaultAsync(d => d.Id == id);

                if (salary == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok(salary); // Department found and returned
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            try
            {
                var salary = await _salaryRepository.DeleteAsync(id);

                if (salary == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok("Salary Deleted Sucessfully"); // Department deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}

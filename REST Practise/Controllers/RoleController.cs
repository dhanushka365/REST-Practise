using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_Practise.Data;
using REST_Practise.Model.DTO;
using REST_Practise.Model.Repositories;
using REST_Practise.Model;
using Microsoft.EntityFrameworkCore;

namespace REST_Practise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ERPContext _dbContext;
        private readonly IMapper _mapper;

        public RoleController(ERPContext dbContext, IMapper mapper, IRoleRepository roleRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var roles = await _dbContext.Roles.ToListAsync();

            // Use the department repository to retrieve additional department data
            var roleDomainModels = await _roleRepository.GetAllAsync();

            // Map the department data to DTOs using AutoMapper
            var roleDtos = _mapper.Map<List<RoleDto>>(roleDomainModels);

            // Combine the data from both sources if needed

            // Return the result as an OK response
            return Ok(roleDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                // Use Entity Framework Core to retrieve a department by its ID
                var role = await _dbContext.Roles.FirstOrDefaultAsync(d => d.Id == id);

                if (role == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok(role); // Department found and returned
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRoleRequestDto addRoleRequestDto)
        {


            var roleDomainModel = _mapper.Map<Role>(addRoleRequestDto);


            await _roleRepository.CreateAsync(roleDomainModel);


            return Ok(_mapper.Map<RoleDto>(roleDomainModel));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoleRequestDto updateRoleRequestDto)
        {
            // Check if a department with the given ID exists
            var existingRole = await _roleRepository.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound(); // Department not found
            }

            // Map the DTO with updated data to the existing domain model
            _mapper.Map(updateRoleRequestDto, existingRole);

            // Use the repository to update the department
            var updatedRole = await _roleRepository.UpdateAsync(existingRole);

            // Map the updated department to a DTO
            var updatedRoleDto = _mapper.Map<RoleDto>(updatedRole);

            return Ok(updatedRoleDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                var role = await _roleRepository.DeleteAsync(id);

                if (role == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok("Role Deleted Sucessfully"); // Department deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}

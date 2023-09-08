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
    public class ProfileController : ControllerBase
    {
        private readonly ERPContext _dbContext;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;


        public ProfileController(ERPContext dbContext, IMapper mapper, IProfileRepository profileRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _profileRepository = profileRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Use Entity Framework Core to retrieve departments from the database
            var profiles = await _dbContext.Profiles.ToListAsync();

            // Use the department repository to retrieve additional department data
            var profileDomainModels = await _profileRepository.GetAllAsync();

            // Map the department data to DTOs using AutoMapper
            var profileDtos = _mapper.Map<List<ProfileDto>>(profileDomainModels);

            // Combine the data from both sources if needed

            // Return the result as an OK response
            return Ok(profileDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Use Entity Framework Core to retrieve a department by its ID
                var profiles = await _dbContext.Profiles.FirstOrDefaultAsync(d => d.Id == id);

                if (profiles == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok(profiles); // Department found and returned
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddProfileRequestDto addProfileRequestDto)
        {

            //Map DTO to domain model
            var profileDomainModel = _mapper.Map<REST_Practise.Model.Profile>(addProfileRequestDto);

            //use Domain model to create difficulty 
            await _profileRepository.CreateAsync(profileDomainModel);

            var profileDto = _mapper.Map<ProfileDto>(profileDomainModel);

            //Map domain model into DTO
            return Ok(profileDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProfileRequestDto updateProfileRequestDto)
        {
            // Check if a department with the given ID exists
            var existingProfile = await _profileRepository.GetByIdAsync(id);
            if (existingProfile == null)
            {
                return NotFound(); // Department not found
            }

            // Map the DTO with updated data to the existing domain model
            _mapper.Map(updateProfileRequestDto, existingProfile);

            // Use the repository to update the department
            var updatedProfile = await _profileRepository.UpdateAsync(existingProfile);

            // Map the updated department to a DTO
            var updatedProfileDto = _mapper.Map<ProfileDto>(updatedProfile);

            return Ok(updatedProfileDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            try
            {
                var profile = await _profileRepository.DeleteAsync(id);

                if (profile == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok("Profile Deleted Sucessfully"); // Department deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}

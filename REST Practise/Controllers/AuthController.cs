
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using REST_Practise.Model;
using REST_Practise.Model.Repositories;
using REST_Practise.Repositories;
using TestWebAPI.Model.DTO;


namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<Profile> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IRoleRepository roleRepository;



        public AuthController(UserManager<Profile> userManager, ITokenRepository tokenRepository, IRoleRepository roleRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.roleRepository = roleRepository;
        }



        // POst : https://localhost:123/api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDTO)
        {
            var profile = new Profile
            {

                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email,
                PhoneNumber = registerRequestDTO.PhoneNumber,
                EmployeeId = registerRequestDTO.EmployeeId,
                RoleId = registerRequestDTO.Roles
            };
            var IdentityResult = await userManager.CreateAsync(profile, registerRequestDTO.Password);

            if (IdentityResult.Succeeded)
            {
                //IdentityResult = await userManager.AddToRolesAsync(profile, registerRequestDTO.Roles);



                if (IdentityResult.Succeeded)
                {
                    return Ok("The User Has been Registered Successfully");
                }

            }
            return BadRequest("Something Went wrong when Registering new user");

        }



        //Post : https://localhost:123/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.Username);



            if (user != null)
            {
                var check = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (check)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var token = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = token,
                        };
                        return Ok(response);
                    }

                }
            }



            return BadRequest("Incorrect Username or Password");
        }
    }
}


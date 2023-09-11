using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using REST_Practise.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace REST_Practise.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJWTToken(Profile profile, List<string> roles)
        {
            //throw new NotImplementedException();

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, profile.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

#pragma warning disable CS8604 // Possible null reference argument.
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
#pragma warning restore CS8604 // Possible null reference argument.
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: configuration["Jwt:Issure"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(150),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}

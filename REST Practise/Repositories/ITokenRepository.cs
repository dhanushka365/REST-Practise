
using Microsoft.AspNetCore.Identity;
using REST_Practise.Model;

namespace REST_Practise.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(Profile profile, Role roles);
      
    }
}

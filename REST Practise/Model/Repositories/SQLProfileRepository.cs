using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;

namespace REST_Practise.Model.Repositories
{
  
    public class SQLProfileRepository : IProfileRepository
    {
        private readonly ERPContext dbcontext;
        public SQLProfileRepository(ERPContext dbcontext)
        {

            this.dbcontext = dbcontext;
        }
        public async Task<List<Profile>> GetAllAsync()
        {
            return await dbcontext.Profiles.ToListAsync();

        }

        public async Task<Profile> CreateAsync(Profile profile)
        {
            dbcontext.Profiles.Add(profile);
            await dbcontext.SaveChangesAsync();
            return profile;
        }


        public async Task<Profile> GetByIdAsync(Guid id)
        {
            return await dbcontext.Profiles.FindAsync(id);
        }

        public Task<Profile> UpdateAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<Profile> UpdateAsync(Profile profile)
        {
            dbcontext.Entry(profile).State = EntityState.Modified; // Mark the department as modified
            await dbcontext.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile> DeleteAsync(Guid id)
        {
            var profile = await dbcontext.Profiles.FindAsync(id); // Find the department by ID

            if (profile != null)
            {
                dbcontext.Profiles.Remove(profile); // Mark the department for deletion
                await dbcontext.SaveChangesAsync(); // Delete the department from the database
            }

            return profile; // Return the deleted department or null if not found
        }
    }
}

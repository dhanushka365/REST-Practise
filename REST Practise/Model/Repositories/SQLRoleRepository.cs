using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;

namespace REST_Practise.Model.Repositories
{
    public class SQLRoleRepository:IRoleRepository
    {
        private readonly ERPContext dbcontext;
        public SQLRoleRepository(ERPContext dbcontext)
        {

            this.dbcontext = dbcontext;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await dbcontext.Roles.ToListAsync();
        }

        public async Task<Role> CreateAsync(Role role)
        {
            dbcontext.Roles.Add(role);
            await dbcontext.SaveChangesAsync();
            return role;
        }


        public async Task<Role> GetByIdAsync(Guid id)
        {
            return await dbcontext.Roles.FindAsync(id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            dbcontext.Entry(role).State = EntityState.Modified; // Mark the department as modified
            await dbcontext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteAsync(Guid id)
        {
            var role = await dbcontext.Roles.FindAsync(id); // Find the department by ID

            if (role != null)
            {
                dbcontext.Roles.Remove(role); // Mark the department for deletion
                await dbcontext.SaveChangesAsync(); // Delete the department from the database
            }

            return role; // Return the deleted department or null if not found
        }
    }
}

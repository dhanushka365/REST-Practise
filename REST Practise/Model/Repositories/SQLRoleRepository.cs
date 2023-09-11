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

        public Task<Role> UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;

namespace REST_Practise.Model.Repositories
{
    public class SQLSalaryRepository :ISalaryRepository
    {
        private readonly ERPContext dbcontext;
        public SQLSalaryRepository(ERPContext dbcontext)
        {

            this.dbcontext = dbcontext;
        }
        
        public async Task<List<Salary>> GetAllAsync()
        {
            return await dbcontext.Salarys.ToListAsync();
        }

        public async Task<Salary> CreateAsync(Salary salary)
        {
            dbcontext.Salarys.Add(salary);
            await dbcontext.SaveChangesAsync();
            return salary;
        }


        public async Task<Salary> GetByIdAsync(Guid id)
        {
            return await dbcontext.Salarys.FindAsync(id);
        }

        public async Task<Salary> UpdateAsync(Salary salary)
        {
            dbcontext.Entry(salary).State = EntityState.Modified; // Mark the department as modified
            await dbcontext.SaveChangesAsync();
            return salary;
        }

        public Task<Salary> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

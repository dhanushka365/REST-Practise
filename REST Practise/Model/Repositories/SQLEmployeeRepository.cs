using Microsoft.EntityFrameworkCore;
using REST_Practise.Data;

namespace REST_Practise.Model.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly ERPContext dbcontext;
        public SQLEmployeeRepository(ERPContext dbcontext)
        {

            this.dbcontext = dbcontext;
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            return await dbcontext.Employees.ToListAsync();
        }


        public async Task<Employee> CreateAsync(Employee employee)
        {
            dbcontext.Employees.Add(employee);
            await dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await dbcontext.Employees.FindAsync(id);
        }

        public async Task<Employee> DeleteAsync(Guid id)
        {
            var employee = await dbcontext.Employees.FindAsync(id); // Find the department by ID

            if (employee != null)
            {
                dbcontext.Employees.Remove(employee); // Mark the department for deletion
                await dbcontext.SaveChangesAsync(); // Delete the department from the database
            }

            return employee; // Return the deleted department or null if not found
        }

        public Task<Employee> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

namespace REST_Practise.Model.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<Employee> DeleteAsync(int id);
    }
}

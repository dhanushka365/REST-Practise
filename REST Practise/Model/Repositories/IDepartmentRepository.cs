namespace REST_Practise.Model.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int id);

        Task<Department> UpdateAsync(Department department);

        Task<Department> CreateAsync(Department department);

        Task <Department> DeleteAsync(int id);

    }
}

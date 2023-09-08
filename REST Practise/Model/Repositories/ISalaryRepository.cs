namespace REST_Practise.Model.Repositories
{
    public interface ISalaryRepository
    {
        Task<List<Salary>> GetAllAsync();
        Task<Salary> GetByIdAsync(int id);
        Task<Salary> CreateAsync(Salary salary);

        Task<Salary> UpdateAsync(Salary salary);
        Task<Salary> DeleteAsync(int id);
    }
}

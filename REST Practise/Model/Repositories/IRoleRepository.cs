namespace REST_Practise.Model.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(Guid id);
        Task<Role> CreateAsync(Role roles);

        Task<Role> UpdateAsync(Role roles);
        Task<Role> DeleteAsync(Guid id);
    }
}

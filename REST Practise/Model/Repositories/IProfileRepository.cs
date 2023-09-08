namespace REST_Practise.Model.Repositories
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(int id);
        Task<Profile> CreateAsync(Profile profiles);

        Task<Profile> UpdateAsync(Profile profile);
        Task<Profile> DeleteAsync(int id);
    }
}

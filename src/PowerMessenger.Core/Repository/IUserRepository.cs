using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository.bases;

namespace PowerMessenger.Core.Repository
{
    public interface IUserRepository:IRepositoryAsync<User>
    {
        Task<User> GetUserByPasswordAsync(string email,string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}

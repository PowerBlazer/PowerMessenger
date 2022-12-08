

using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository.bases;

namespace PowerMessenger.Core.Repository
{
    public interface IUserRepository:IRepositoryAsync<User>
    {
        Task<User> GetUserByEmailPasswordAsync(string email, string password);
    }
}

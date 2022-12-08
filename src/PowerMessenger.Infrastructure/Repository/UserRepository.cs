using Microsoft.EntityFrameworkCore;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository;


namespace PowerMessenger.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContextEF _contextEF;
        private readonly IApplicationContextDapper _contextDapper;
        public UserRepository(IApplicationContextEF contextEF, IApplicationContextDapper contextDapper)
        {
            _contextEF = contextEF;
            _contextDapper = contextDapper;
        }
        public async Task<User> AddAsync(User entity)
        {
            _contextEF.Users.AddRange(entity);

            await _contextEF.SaveChangesAsync();

            return entity;
        }

        public Task<User> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _contextEF.Users.ToListAsync();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailPasswordAsync(string email,string password)
        {
            var result = await _contextEF.Users
                .FirstOrDefaultAsync(p => p.Email == email && p.PasswordHash == password);

            return result!;
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

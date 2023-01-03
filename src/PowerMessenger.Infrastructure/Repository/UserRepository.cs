using Dapper;
using Microsoft.EntityFrameworkCore;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.DTO.Authorization;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository;
using System.Data;

namespace PowerMessenger.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContextEF _contextEF;
        private readonly IApplicationContextDapper _contextDapper;
        public UserRepository (IApplicationContextDapper contextDapper,IApplicationContextEF contextEF)
        {
            _contextEF = contextEF;
            _contextDapper = contextDapper;
        }
        public async Task<User> AddUserAsync(User entity)
        {
            string query = @"INSERT INTO Users(Name,PasswordHash,Email,PhoneNumber,DateRegistration,Photo)
                                VALUES(@name,@password,@email,@phone,@date,@photo)";

            using (IDbConnection connection = _contextDapper.CreateConnection())
            {
                await connection.ExecuteAsync(query,new
                {                   
                    name = entity.Name,
                    password = entity.PasswordHash,
                    email = entity.Email,
                    phone = entity.PhoneNumber,
                    date = entity.DateRegistration,
                    photo = entity.Photo,
                });
            }

            return entity;
        }

        public Task<User> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
           return await _contextEF.Users.ToListAsync();
        }

        public Task<User> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            string query = "SELECT * FROM Users Where Email = @email";

            using (IDbConnection connection = _contextDapper.CreateConnection())
            {
                User result = await connection.QueryFirstOrDefaultAsync<User>(query, new
                {
                    email = email 
                });

                return result;
            }
        }

        public async Task<User> GetUserByPasswordAsync(string email, string password)
        {
            string query = "SELECT * FROM Users Where Email = @email AND PasswordHash = @password";

            using(IDbConnection connection = _contextDapper.CreateConnection())
            {
                User result = await connection.QueryFirstOrDefaultAsync<User>(query, new
                {
                    email = email,
                    password = password
                });

                return result;
            }
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

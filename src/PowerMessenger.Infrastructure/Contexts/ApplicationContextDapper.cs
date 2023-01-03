using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PowerMessenger.Core.Contexts;
using System.Data;


namespace PowerMessenger.Infrastructure.Contexts
{
    public class ApplicationContextDapper : IApplicationContextDapper
    {
        private readonly IConfiguration _configuration;

        public ApplicationContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_configuration.GetConnectionString("MySqlConnection"));
        }
    }
}

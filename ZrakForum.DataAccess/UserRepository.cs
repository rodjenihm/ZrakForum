using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionString connectionString;

        public UserRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync(User user)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspRegisterUser @Id, @Username, @PasswordHash, @ImageUrl";
            await connection.ExecuteAsync(sql, user);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspGetUserByUsername @Username";
            return await connection.QueryFirstAsync<User>(sql, new { Username = username });
        }
    }
}

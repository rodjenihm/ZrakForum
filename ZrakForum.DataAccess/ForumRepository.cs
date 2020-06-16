using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class ForumRepository : IForumRepository
    {
        private readonly ConnectionString connectionString;

        public ForumRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync(Forum forum)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspCreateForum @Id, @Name, @Description";
            await connection.ExecuteScalarAsync<int>(sql, forum);
        }

        public async Task<IEnumerable<Forum>> GetAllAsync()
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetAllForums";
            return await connection.QueryAsync<Forum>(sql);
        }

        public async Task<IEnumerable<dynamic>> GetAllForumIndexInfosAsync()
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetAllForumIndexInfos";
            return await connection.QueryAsync(sql);
        }

        public async Task<Forum> GetByIdAsync(string id)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetForumById @Id";
            return await connection.QueryFirstAsync<Forum>(sql, new { Id = id });
        }
    }
}

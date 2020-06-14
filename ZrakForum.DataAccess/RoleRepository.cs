using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ConnectionString connectionString;

        public RoleRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Role>> GetByUserIdAsync(string userId)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspGetRolesByUserId @UserId";
            return await connection.QueryAsync<Role>(sql, new { UserId = userId });
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ConnectionString connectionString;

        public TopicRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync(Topic topic)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspCreateTopic @Id, @Title, @Description, @AuthorId, @ForumId";
            await connection.ExecuteAsync(sql, topic);
        }
    }
}

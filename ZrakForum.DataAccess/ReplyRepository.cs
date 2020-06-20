using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly ConnectionString connectionString;

        public ReplyRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task CreateAsync(Reply reply)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspCreateReply @Id, @Text, @AuthorId, @TopicId";
            await connection.ExecuteAsync(sql, reply);
        }
    }
}

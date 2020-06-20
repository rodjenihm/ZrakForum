using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ConnectionString connectionString;

        public MessageRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync(Message message)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = "uspCreateMessage @Id, @Text, @SenderId, @ReceiverId";
            await connection.ExecuteAsync(sql, message);
        }
    }
}

using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
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
            var sql = "uspCreateMessage @Id, @Subject, @Text, @SenderId, @ReceiverId";
            await connection.ExecuteAsync(sql, message);
        }

        public async Task<Message> GetByIdAsync(string id)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetMessageById @Id";
            return await connection.QueryFirstAsync<Message>(sql, new { Id = id });
        }

        public async Task<IEnumerable<ReceivedMessage>> GetReceivedMessagesByUserId(string userId)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetReceivedMessagesByUserId @UserId";
            return await connection.QueryAsync<ReceivedMessage>(sql, new { UserId = userId });
        }

        public async Task<IEnumerable<SentMessage>> GetSentMessagesByUserId(string userId)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetSentMessagesByUserId @UserId";
            return await connection.QueryAsync<SentMessage>(sql, new { UserId = userId });
        }
    }
}

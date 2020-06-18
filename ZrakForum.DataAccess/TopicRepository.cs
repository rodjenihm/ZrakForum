using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
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

        public async Task<TopicShow> GetTopicShowByIdAsync(string Id)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetTopicShowById @Id";

            var lookup = new Dictionary<string, TopicShow>();

            var result = await connection.QueryAsync(
                sql,
                (Func<TopicShow, TopicShowReplyInfo, TopicShow>)((t, r) =>
                {
                    if (!lookup.TryGetValue(t.TopicId, out TopicShow topicSHow))
                        lookup.Add(t.TopicId, topicSHow = t);

                    if (topicSHow.Replies == null)
                        topicSHow.Replies = new List<TopicShowReplyInfo>();

                    if (r != null)
                        topicSHow.Replies.Add(r);

                    return topicSHow;
                }),
                new { Id });

            return lookup.Values.FirstOrDefault();
        }
    }
}

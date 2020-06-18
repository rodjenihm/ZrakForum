using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
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
            await connection.ExecuteAsync(sql, forum);
        }

        public async Task<IEnumerable<Forum>> GetAllAsync()
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetAllForums";
            return await connection.QueryAsync<Forum>(sql);
        }

        public async Task<IEnumerable<ForumIndexInfo>> GetAllForumIndexInfosAsync()
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetAllForumIndexInfos";
            return await connection.QueryAsync<ForumIndexInfo>(sql);
        }

        public async Task<Forum> GetByIdAsync(string id, bool includeTopics = false)
        {
            using var connection = new SqlConnection(connectionString.Value);

            if (includeTopics)
            {
                var forum = await GetForumWithThreadsAsync(id, connection);
                return forum;
            }
            else
            {
                var sql = @"uspGetForumById @Id";
                return await connection.QueryFirstAsync<Forum>(sql, new { Id = id });
            }
        }
        public async Task<IEnumerable<ForumShow>> GetForumShowByIdAsync(string Id)
        {
            using var connection = new SqlConnection(connectionString.Value);
            var sql = @"uspGetForumShowById @Id";

            var lookup = new Dictionary<string, ForumShow>();

            var result = await connection.QueryAsync(
                sql,
                (Func<ForumShow, ForumShowTopicInfo, ForumShow>)((f, t) =>
                {
                    if (!lookup.TryGetValue(f.ForumId, out ForumShow forumShow))
                        lookup.Add(f.ForumId, forumShow = f);

                    if (forumShow.Topics == null)
                        forumShow.Topics = new List<ForumShowTopicInfo>();

                    if (t != null)
                        forumShow.Topics.Add(t);

                    return forumShow;
                }),
                new { Id });

            return lookup.Values;
        }

        // Helpers
        private static async Task<Forum> GetForumWithThreadsAsync(string id, SqlConnection dbConnection)
        {
            var sql = "uspGetForumWithTopicsByIdAsync @Id";
            var lookup = new Dictionary<string, Forum>();
            var forum = (await dbConnection.QueryAsync(sql, MapForumWithThreads(lookup), new { Id = id })).FirstOrDefault();
            return forum;
        }

        // After joining three tables (Forums, Threads and Accounts) we need to tell Dapper how to construct complex forum model
        private static Func<Forum, Topic, User, Forum> MapForumWithThreads(Dictionary<string, Forum> lookup)
        {
            return (f, t, u) =>
            {
                if (!lookup.TryGetValue(f.Id, out Forum forum))
                {
                    lookup.Add(f.Id, forum = f);
                }

                if (forum.Topics == null)
                {
                    forum.Topics = new List<Topic>();
                }

                if (t != null)
                {
                    t.Author = u;
                    forum.Topics.Add(t);
                }

                return forum;
            };
        }

    }
}

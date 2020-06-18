using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IForumRepository
    {
        Task<IEnumerable<Forum>> GetAllAsync();
        Task<Forum> GetByIdAsync(string id, bool includeTopics);
        Task CreateAsync(Forum forum);
        Task<IEnumerable<ForumIndexInfo>> GetAllForumIndexInfosAsync();
        Task<ForumShow> GetForumShowByIdAsync(string Id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IForumRepository
    {
        Task<IEnumerable<Forum>> GetAllAsync();
        Task<Forum> GetByIdAsync(string id);
        Task CreateAsync(Forum forum);
    }
}

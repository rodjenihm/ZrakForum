using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface ITopicRepository
    {
        Task CreateAsync(Topic topic);
        Task<TopicShow> GetTopicShowByIdAsync(string Id);
    }
}

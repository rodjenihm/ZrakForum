using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface ITopicRepository
    {
        Task CreateAsync(Topic topic);
    }
}

using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IReplyRepository
    {
        Task CreateAsync(Reply reply);
    }
}

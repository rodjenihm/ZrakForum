using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IMessageRepository
    {
        Task CreateAsync(Message message);
    }
}

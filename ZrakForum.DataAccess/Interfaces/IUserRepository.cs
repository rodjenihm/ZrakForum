using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}

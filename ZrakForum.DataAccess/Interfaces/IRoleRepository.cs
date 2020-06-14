using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetByUserIdAsync(string userId);
    }
}

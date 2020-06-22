using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Models;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess
{
    public interface IMessageRepository
    {
        Task CreateAsync(Message message);
        Task<IEnumerable<ReceivedMessage>> GetReceivedMessagesByUserId(string userId);
        Task<IEnumerable<SentMessage>> GetSentMessagesByUserId(string userId);
    }
}

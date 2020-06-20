using System.Collections.Generic;

namespace ZrakForum.DataAccess.Models
{
    public class ForumShow
    {
        public string ForumId { get; set; }
        public string ForumName { get; set; }
        public ICollection<ForumShowTopicInfo> Topics { get; set; }
    }
}

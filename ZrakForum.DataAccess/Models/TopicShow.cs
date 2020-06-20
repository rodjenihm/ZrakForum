using System.Collections.Generic;

namespace ZrakForum.DataAccess.Models
{
    public class TopicShow
    {
        public string TopicId { get; set; }
        public string TopicTitle { get; set; }
        public ICollection<TopicShowReplyInfo> Replies { get; set; }
    }
}

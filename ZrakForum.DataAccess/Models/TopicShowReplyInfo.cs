using System;

namespace ZrakForum.DataAccess.Models
{
    public class TopicShowReplyInfo
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public string AuthorUsername { get; set; }
        public DateTime ReplyAt { get; set; }
    }
}

using System;

namespace ZrakForum.DataAccess.Models
{
    public class ForumShowTopicInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartedBy { get; set; }
        public DateTime StartedAt { get; set; }
        public int RepliesCount { get; set; }
        public string LastReplyBy { get; set; }
        public DateTime LastReplyAt { get; set; }
    }
}

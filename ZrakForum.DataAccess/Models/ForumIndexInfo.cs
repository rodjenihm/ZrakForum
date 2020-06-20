using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZrakForum.EntityModel;

namespace ZrakForum.DataAccess.Models
{
    public class ForumIndexInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TopicsCount { get; set; }
        public int RepliesCount { get; set; }
        public string LastPostedBy { get; set; }
        public string LastPostedInId { get; set; }
        public string LastPostedIn { get; set; }
        public DateTime LastPostedAt { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class Topic : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class Reply : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class Message : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}

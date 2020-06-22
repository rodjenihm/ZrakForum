using System;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.DataAccess.Models
{
    public class SentMessage
    {
        [Display(Name = "Poslato")]
        public DateTime SentAt { get; set; }
        public string Id { get; set; }
        [Display(Name = "Naslov")]
        public string Subject { get; set; }
        public string Text { get; set; }
        public string ReceiverId { get; set; }
        [Display(Name = "Primalac")]
        public string ReceiverUsername { get; set; }
    }
}

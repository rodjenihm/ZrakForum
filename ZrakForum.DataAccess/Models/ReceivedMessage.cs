using System;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.DataAccess.Models
{
    public class ReceivedMessage
    {
        [Display(Name = "Primljeno")]
        public DateTime ReceivedAt { get; set; }
        public string Id { get; set; }
        [Display(Name = "Naslov")]
        public string Subject { get; set; }
        public string Text { get; set; }
        public string ReceiverId { get; set; }
        [Display(Name = "Pošiljalac")]
        public string SenderUsername { get; set; }
    }
}

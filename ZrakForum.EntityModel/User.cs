using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(48)]
        public string PasswordHash { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
    }
}

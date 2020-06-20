using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(48)]
        public string PasswordHash { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}

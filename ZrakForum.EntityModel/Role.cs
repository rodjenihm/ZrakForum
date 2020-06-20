using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.EntityModel
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

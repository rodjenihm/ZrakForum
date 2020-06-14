﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZrakForum.EntityModel
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}

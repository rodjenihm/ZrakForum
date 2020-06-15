using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZrakForum.Web.Dto
{
    public class ForumAddDto
    {
        [Required(ErrorMessage = "{0} je obavezno")]
        [Display(Name = "Ime foruma")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} je obavezan")]
        [MinLength(11, ErrorMessage = "{0} mora imati najmanje {1} karaktera")]
        [Display(Name = "Opis foruma")]
        public string Description { get; set; }
    }
}

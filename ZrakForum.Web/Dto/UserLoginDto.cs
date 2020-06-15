using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZrakForum.Web.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "{0} je obavezno")]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} je obavezna")]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZrakForum.Web.Dto
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "{0} je obavezno")]
        [StringLength(30, ErrorMessage = "{0} mora imati najmanje {2} a najviše {1} karaktera", MinimumLength = 4)]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} je obavezna")]
        [StringLength(30, ErrorMessage = "{0} mora imati najmanje {2} a najviše {1} karaktera", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite šifru")]
        [Compare("Password", ErrorMessage = "Šifre se ne podudaraju")]
        public string ConfirmPassword { get; set; }
    }
}

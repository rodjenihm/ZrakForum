using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZrakForum.Web.Dto
{
    public class MessageComposeDto
    {
        [Required(ErrorMessage = "{0} je obavezan")]
        [MaxLength(30, ErrorMessage = "{0} mora imati najviše {1} karaktera")]
        [Display(Name = "Naslov")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "{0} je obavezan")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Tekst poruke")]
        public string Text { get; set; }
    }
}

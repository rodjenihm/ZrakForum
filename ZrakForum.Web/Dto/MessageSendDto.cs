using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZrakForum.Web.Dto
{
    public class MessageSendDto
    {
        [Required(ErrorMessage = "{0} je obavezan")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Tekst poruke")]
        public string Text { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ZrakForum.Web.Dto
{
    public class ReplyCreateDto
    {
        [Required(ErrorMessage = "{0} ne može biti prazan")]
        [Display(Name = "Komentar")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}

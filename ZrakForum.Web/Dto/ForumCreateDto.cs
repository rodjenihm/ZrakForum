using System.ComponentModel.DataAnnotations;

namespace ZrakForum.Web.Dto
{
    public class ForumCreateDto
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

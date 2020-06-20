using System.ComponentModel.DataAnnotations;

namespace ZrakForum.Web.Dto
{
    public class TopicCreateDto
    {
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(255, ErrorMessage = "{0} ime mora imati najviše {1} karaktera")]
        [Display(Name = "Naziv teme")]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0} je obavezan")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Uvodni komentar")]
        public string Description { get; set; }
    }
}

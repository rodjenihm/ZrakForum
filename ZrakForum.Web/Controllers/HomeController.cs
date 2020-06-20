using Microsoft.AspNetCore.Mvc;
using ZrakForum.DataAccess;

namespace ZrakForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForumRepository forumRepository;

        public HomeController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Forum");
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

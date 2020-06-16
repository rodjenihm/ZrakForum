using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZrakForum.DataAccess;
using ZrakForum.Web.Model;

namespace ZrakForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForumRepository forumRepository;

        public HomeController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public async Task<IActionResult> Index()
        {
            var forums = (await forumRepository.GetAllForumIndexInfosAsync());
            return View(forums);
        }
    }
}

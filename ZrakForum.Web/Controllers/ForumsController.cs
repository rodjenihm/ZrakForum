using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZrakForum.DataAccess;
using ZrakForum.EntityModel;
using ZrakForum.Web.Dto;

namespace ZrakForum.Web.Controllers
{
    public class ForumsController : Controller
    {
        private readonly IForumRepository forumRepository;

        public ForumsController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }
        public async Task<IActionResult> Index()
        {
            var forums = await forumRepository.GetAllAsync();
            return View(forums);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ForumAddDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var forum = new Forum
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = model.Name,
                Description = model.Description
            };

            try
            {
                await forumRepository.CreateAsync(forum);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(model);
            }
        }
    }

}

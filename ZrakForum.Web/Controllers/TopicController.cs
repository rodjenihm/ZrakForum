using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZrakForum.DataAccess;
using ZrakForum.EntityModel;
using ZrakForum.Web.Dto;

namespace ZrakForum.Web.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly ITopicRepository topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        public IActionResult Create(string forumId)
        {
            ViewBag.ForumId = forumId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicCreateDto model, string forumId)
        {
            if (!ModelState.IsValid)
                return View(model);

            var authorId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var topic = new Topic
            {
                Id = Guid.NewGuid().ToString("N"),
                Title = model.Title,
                Description = model.Description,
                AuthorId = authorId,
                ForumId = forumId
            };

            try
            {
                await topicRepository.CreateAsync(topic);
                return RedirectToAction("Show", "Forum", new { id = forumId });
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Show(string id)
        {
            try
            {
                var topic = await topicRepository.GetTopicShowByIdAsync(id);
                return View(topic);
            }
            catch (Exception)
            {
                return View(null);
            }
        }
    }
}

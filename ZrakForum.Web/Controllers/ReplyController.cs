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
    public class ReplyController : Controller
    {
        private readonly IReplyRepository replyRepository;

        public ReplyController(IReplyRepository replyRepository)
        {
            this.replyRepository = replyRepository;
        }

        public IActionResult Create(string topicId)
        {
            ViewBag.TopicId = topicId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReplyCreateDto model, string topicId)
        {
            if (!ModelState.IsValid)
                return View(model);

            var authorId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var reply = new Reply
            {
                Id = Guid.NewGuid().ToString("N"),
                Text = model.Text,
                AuthorId = authorId,
                TopicId = topicId
            };

            try
            {
                await replyRepository.CreateAsync(reply);
                return RedirectToAction("Show", "Topic", new { id = topicId });
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(model);
            }
        }
    }
}

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
    public class MessagesController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;

        public MessagesController(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Inbox");
        }

        public IActionResult Compose(string sendTo)
        {
            ViewBag.SendTo = sendTo;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageComposeDto model, string sendTo)
        {
            if (string.IsNullOrEmpty(sendTo))
            {
                ViewBag.Error = "Niste naveli korisničko ime kome je upućena poruka";
                return View("Compose", model);
            }

            var senderId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            var receiverId = (await userRepository.GetByUsernameAsync(sendTo)).Id;

            var message = new Message
            {
                Id = Guid.NewGuid().ToString("N"),
                Subject = model.Subject,
                Text = model.Text,
                SenderId = senderId,
                ReceiverId = receiverId
            };

            try
            {
                await messageRepository.CreateAsync(message);
                return RedirectToAction("Outbox", "Messages");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Compose", model);
            }
        }

        public async Task<IActionResult> Inbox()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var receivedMessages = await messageRepository.GetReceivedMessagesByUserId(id);
            return View(receivedMessages);
        }

        public async Task<IActionResult> Outbox()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            var sentMessages = await messageRepository.GetSentMessagesByUserId(id);
            return View(sentMessages);
        }
    }
}

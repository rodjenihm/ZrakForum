﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZrakForum.DataAccess;
using ZrakForum.EntityModel;
using ZrakForum.Web.Dto;
using ZrakForum.Web.Model;

namespace ZrakForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumRepository forumRepository;

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ForumAddDto model)
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

        public async Task<IActionResult> Show(string id)
        {
            try
            {
                var forum = await forumRepository.GetByIdAsync(id);
                return View(forum);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
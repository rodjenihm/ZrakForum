using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZrakForum.DataAccess;
using ZrakForum.EntityModel;
using ZrakForum.Services;
using ZrakForum.Web.Dto;
using ZrakForum.Web.Model;

namespace ZrakForum.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IPasswordHasher passwordHasher;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.passwordHasher = passwordHasher;
        }

        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userRepository.GetByUsernameAsync(model.Username);

            if (user == null || !passwordHasher.VerifyHashedPassword(model.Password, user.PasswordHash))
            {
                ViewBag.Error = "Korisničko ime ili šifra su pogrešni";
                return View(model);
            }

            var userPrincipal = await GenerateUserPrincipal(user);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

            return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("Index", "Home") : (IActionResult)LocalRedirect(returnUrl);
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                Id = Guid.NewGuid().ToString("N"),
                Username = model.Username,
                PasswordHash = passwordHasher.HashPassword(model.Password),
                ImageUrl = "/img/profile.png"
            };

            try
            {
                await userRepository.CreateAsync(user);
                var userPrincipal = await GenerateUserPrincipal(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Show(string username)
        {
            var user = await userRepository.GetByUsernameAsync(username);
            var userShow = new UserShowViewModel
            {
                CreatedAt = user.CreatedAt,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl
            };

            return View(userShow);
        }

        private async Task<ClaimsPrincipal> GenerateUserPrincipal(User user)
        {
            var userRoles = await roleRepository.GetByUserIdAsync(user.Id);

            var zrakClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id", user.Id)
            };

            foreach (var userRole in userRoles)
            {
                zrakClaims.Add(new Claim(ClaimTypes.Role, userRole.Name));
            }

            var zrakIdentity = new ClaimsIdentity(zrakClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(new[] { zrakIdentity });
            return userPrincipal;
        }

    }
}

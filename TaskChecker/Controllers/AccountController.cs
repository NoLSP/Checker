using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskChecker.ViewModels;
using TaskChecker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace TaskChecker.Controllers
{
    public class AccountController : Controller
    {
        private DataContext dataContext;
        public AccountController(DataContext context)
        {
            dataContext = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await dataContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Lk", "Users", new { userId = user.Id});
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var userRoles = dataContext.UserRoles
                .Where(x => x.Name != "Administrator")
                .Select(x => new SelectListItem()
                {
                    Value = $"{x.Id}",
                    Text = x.Title
                }).ToList();

            return View(new RegisterViewModel() { UserRoles = userRoles});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await dataContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User 
                    { 
                        Email = model.Email, 
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        Title = model.LastName + " " + model.FirstName,
                        Role_id = model.UserRoleId,
                        CreationDateTime = System.DateTime.UtcNow
                    };

                    dataContext.Users.Add(user);
                    await dataContext.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Lk", "Users", new { userId = user.Id });
                }
                else
                    ModelState.AddModelError("", "Такой пользователь уже зарегистрирован");
            }
            return View(model);
        }

        private async System.Threading.Tasks.Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, dataContext.UserRoles.Find(user.Role_id).Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}

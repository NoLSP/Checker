using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskChecker.ViewModels;
using TaskChecker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TaskChecker.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BaseController : Controller
    {
        private DataContext dataContext;
        public BaseController(DataContext context)
        {
            dataContext = context;
        }

        [HttpGet]
        public ActionResult Install()
        {
            //Устанавливаем справочники
            TestState.Install(dataContext);
            TaskState.Install(dataContext);
            ProgrammingLanguage.Install(dataContext);
            NotificationType.Install(dataContext);
            NotificationChannel.Install(dataContext);

            return View();
        }
    }
}

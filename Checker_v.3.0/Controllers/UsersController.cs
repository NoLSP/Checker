using Checker_v._3._0.Helpers;
using Checker_v._3._0.Models;
using Checker_v._3._0.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checker_v._3._0.Controllers
{
    public class UsersController : Controller
    {
        private DataContext dataContext;

        public UsersController(DataContext context)
        {
            dataContext = context;
        }

        [Authorize]
        public ActionResult Profile()
        {
            var userRole = User.Role();
            var user = dataContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

            if (user == null)
            {
                return ResultHelper.UserNotFound();
            }

            if (String.IsNullOrWhiteSpace(userRole))
            {
                return ResultHelper.Failed("У пользователя не указана роль");
            }

            if(userRole == "Student")
            {
                return StudentProfile(dataContext.Users.Find());
            }
            else if(userRole == "Teacher")
            {
                return TeacherProfile(user);
            }

            return ResultHelper.Failed("Роль пользователя не найдена в системе" );
        }

        private ActionResult StudentProfile(User user)
        {
            //var tasks = dataContext.StudentsTaskResults
            //    .Where(x => x.Student_id == user.Id)
            //    .Select(x => new TaskDto()
            //    {
            //        Id = x.Id,
            //        Title = x.Task.Title,
            //        StudentResult = x.TeacherResult ?? 0,
            //        MaxResult = x.Task.MaxResult
            //    }).ToList();

            //var group = dataContext.StuentsInGroups
            //    .Include(x => x.Group)
            //    .First(x => x.Student_id == user.Id)
            //    .Group;

            //var profileDto = new UserDto()
            //{
            //    Id = user.Id,
            //    ShortName = user.ShortName,
            //    FullName = user.FullName,
            //    GroupId = group.Id,
            //    GroupTitle = group.Title,
            //    Points = tasks.Sum(x => x.StudentResult),
            //    TotalPoints = tasks.Sum(x => x.MaxResult),
            //    Tasks = tasks
            //};

            return View();
        }

        private ActionResult TeacherProfile(User user)
        {
            var model = new TeacherViewModel()
            {
                FullName = user.FullName,
                Id = user.Id,
                ShortName = user.ShortName,
                Email = user.Email,
                RoleName = dataContext.UserRoles.FirstOrDefault(x => x.Id == user.Role_id).Title
            };

            return View("TeacherProfile", model);
        }
    }
}

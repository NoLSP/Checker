using TaskChecker.Helpers;
using TaskChecker.Models;
using TaskChecker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Controllers
{
    public class UsersController : Controller
    {
        private DataContext dataContext;

        public UsersController(DataContext context)
        {
            dataContext = context;
        }

        [Authorize]
        public ActionResult Lk(int userId)
        {
            var userRole = User.Role();
            var user = dataContext.Users.Find(userId);

            if (user == null)
            {
                return ResultHelper.UserNotFound();
            }

            if (String.IsNullOrWhiteSpace(userRole))
            {
                return ResultHelper.Failed("У пользователя не указана роль");
            }

            if (userRole == "Administrator")
            {
                return AdminLk(user);
            }
            else if (userRole == "Student")
            {
                return StudentLk(user);
            }
            else if (userRole == "Teacher")
            {
                return TeacherLk(user);
            }

            return ResultHelper.Failed("Роль пользователя не найдена в системе" );
        }

        private ActionResult StudentLk(User student)
        {
            var studentsGroupDatailUrl = "https://" + this.HttpContext.Request.Host + $"/Students/StudentsGroupDetail?groupId={student.StudentsGroup_id}";

            var courseDatailUrl = "https://" + this.HttpContext.Request.Host + "/Students/CourseDetail?courseId=";

            var courses = (List<CourseDto>)null;
            if (student.Group != null)
            {
                courses = student.Group.Courses
                    .Select(x => new CourseDto()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        DetailUrl = courseDatailUrl + x.Id,
                        Owner = new UserDto()
                        {
                            Id = x.Owner.Id,
                            Title = x.Owner.Title
                        }
                    }).ToList();
            }

            var model = new StudentViewModel()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Id = student.Id,
                Email = student.Email,
                Courses = courses,
                Group = student.Group == null ? null : new StudentsGroupDto() 
                { 
                    Id = student.Group.Id,
                    Title = student.Group.Title
                }
            };

            return View("StudentLk", model);
        }

        private ActionResult AdminLk(User user)
        {
            var model = new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Id = user.Id,
                Email = user.Email
            };

            return View("AdminLk", model);
        }

        private ActionResult TeacherLk(User user)
        {
            var groupDatailUrl = "https://" + this.HttpContext.Request.Host + "/Teachers/StudentsGroupDetail?groupId=";

            var studentsGroups = dataContext.StudentsGroups
                .Where(x => x.Owner_id == user.Id)
                .Select(x => new StudentsGroupDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DetailUrl = groupDatailUrl + x.Id
                }).ToList();

            var courseDatailUrl = "https://" + this.HttpContext.Request.Host + "/Teachers/CourseDetail?courseId=";

            var courses = dataContext.Courses
                .Where(x => x.Owner_id == user.Id)
                .Select(x => new CourseDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DetailUrl = courseDatailUrl + x.Id
                }).ToList();

            var model = new TeacherViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Id = user.Id,
                Email = user.Email,
                StudentsGroups = studentsGroups,
                Courses = courses
            };

            return View("TeacherLk", model);
        }
    }
}

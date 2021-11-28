using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checker_v._3._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Checker_v._3._0.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private DataContext dataContext;

        public StudentsController(DataContext context)
        {
            dataContext = context;
        }

        public IActionResult List()
        {
            var students = dataContext.Users
                .Where(x => x.Role.Name == "Student")
                .ToList()
                .Select(x => new StudentDto()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.Title,
                    GroupTitle = x.Group.Title
                }).ToList();

            //Потом можно добавить привязку к преподавателю

            return View(students);
        }
    }
}

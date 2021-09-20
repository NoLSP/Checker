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
    public class TasksController : Controller
    {
        private DataContext dataContext;
        public TasksController(DataContext context)
        {
            dataContext = context;
        }

        public ActionResult List()
        {
            var tasks = dataContext.Tasks
                .Select(x => new TaskForListDto() 
                { 
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    TaskGroupTitle = x.Group.Title,
                    MaxResult = x.MaxResult
                });

            return View("TeacherList", tasks);
        }

        public ActionResult Create(TaskViewModel model)
        {

        }
    }
}

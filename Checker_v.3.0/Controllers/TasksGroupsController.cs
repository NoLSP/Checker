using System;
using System.Collections.Generic;
using System.Linq;
using Checker_v._3._0.Helpers;
using Checker_v._3._0.Models;
using Checker_v._3._0.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Checker_v._3._0.Controllers
{
    [Authorize]
    public class TasksGroupsController : Controller
    {
        private DataContext dataContext;

        public TasksGroupsController(DataContext context)
        {
            dataContext = context;
        }

        public ActionResult List()
        {
            var tasks = dataContext.TaskGroups
                .Select(x => new TaskGroupDto() 
                { 
                    Id = x.Id,
                    Title = x.Title,
                    Name = x.Name
                });

            return View("List", tasks);
        }

        public ActionResult _CreateForm()
        {
            var taskGroups = dataContext.TaskGroups
                .Select(x => new SelectListItem()
                {
                    Text = x.Title,
                    Value = $"{x.Id}"
                }).ToList();

            return View("_CreateForm", new CreateTaskViewModel() { TaskGroups = taskGroups });
        }

        [HttpPost]
        public ActionResult Create(CreateTaskViewModel model)
        {
            var taskGroup = dataContext.TaskGroups.Find(model.GroupId);

            if (taskGroup == null)
                return ResultHelper.Failed($"Курса #{model.GroupId} не существует.");

            var taskToCreate = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                Group_id = taskGroup.Id,
                MaxResult = model.MaxResult
            };

            dataContext.Entry(taskToCreate).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect("/Tasks/List");
        }
    }
}

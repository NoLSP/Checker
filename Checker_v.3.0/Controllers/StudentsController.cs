using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checker_v._3._0.Helpers;
using Checker_v._3._0.Models;
using Checker_v._3._0.ViewModels;
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

        public ActionResult CourseDetail(int courseId)
        {
            var course = dataContext.Courses
                .Find(courseId);

            if (course == null)
                return ResultHelper.EntityNotFound("Course");

            var student = Checker_v._3._0.Models.User.Get(dataContext, HttpContext);

            if (student == null)
                return ResultHelper.UserNotFound();

            if (!course.StudentsGroups.Contains(student.Group))
                return ResultHelper.Failed($"Курс {{{courseId}}} не прикреплен к группе текущего пользователя");

            var courseDto = new CourseDto()
            {
                Id = course.Id,
                Title = course.Title,
                Name = course.Name,
                Tasks = dataContext.Tasks
                    .Where(y => y.Course_id == course.Id)
                    .Select(y => new TaskDto()
                    {
                        Id = y.Id,
                        Title = y.Title,
                        Description = y.Description,
                        MaxResult = y.MaxResult
                    }).ToList(),
                TasksResults = dataContext.StudentsTaskTeacherResults
                    .Where(y => y.Task.Course_id == course.Id)
                    .Where(y => y.Student_id == student.Id)
                    .Select(y => new StudentTaskTeacherResultDto()
                    {
                        Id = y.Id,
                        StudentId = y.Student_id,
                        TaskId = y.Task_id,
                        TeacherResult = y.TeacherResult
                    }).ToList()
            };

            var studentCourse = new StudentCourseDto()
            {
                Student = new StudentViewModel()
                {
                    FullName = student.Title,
                    Id = student.Id,
                    ShortName = student.ShortName,
                    Email = student.Email,
                    Group = new StudentsGroupDto()
                    {
                        Id = student.Group.Id,
                        Title = student.Group.Title
                    }
                },
                Course = courseDto,
                SummStudentResult = courseDto.TasksResults.Sum(x => x.TeacherResult ?? 0),
                SummResult = courseDto.Tasks.Sum(x => x.MaxResult)
            };

            return View(studentCourse);
        }
    }
}

using TaskChecker.Models;
using TaskChecker.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskChecker.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace TaskChecker.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachersController : Controller
    {
        private DataContext dataContext;
        private IWebHostEnvironment appEnvironment;

        public TeachersController(DataContext context, IWebHostEnvironment appEnvironment)
        {
            dataContext = context;
            this.appEnvironment = appEnvironment;
        }

        public ActionResult StudentsGroupDetail(int groupId)
        {
            var group = dataContext.StudentsGroups
                .Find(groupId);

            if (group == null)
                return ResultHelper.EntityNotFound("StudentsGroup");

            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            if (group.Owner_id != user.Id)
                return ResultHelper.Failed($"Группа {{{groupId}}} не принадлежит текущему пользователю");

            var students = group.Students
                .Where(x => x.Id != user.Id)
                .Select(x => new UserDto()
                {
                    Id = x.Id,
                    Title = x.Title,

                }).ToList();

            var studentIds = students.Select(x => x.Id);

            var url = "https://" + HttpContext.Request.Host + "/Teachers/StudentTaskResult?";

            var courses = dataContext.StudentsGroupCourses
                .Where(x => x.Course.Owner_id == user.Id)
                .Where(x => x.StudentsGroup_id == groupId)
                .Where(x => x.StudentsGroup.Owner_id == user.Id)
                .Select(x => new CourseDto()
                {
                    Id = x.Course.Id,
                    Title = x.Course.Title,
                    Name = x.Course.Name,
                    Tasks = dataContext.Tasks
                        .Where(y => y.Course_id == x.Course_id)
                        .Select(y => new TaskDto()
                        {
                            Id = y.Id,
                            Title = y.Title,
                            MaxResult = y.MaxResult
                        }).ToList(),
                    TasksResults = dataContext.StudentsTaskTeacherResults
                        .Where(y => y.Task.Course_id == x.Course_id)
                        .Where(y => studentIds.Contains(y.Student_id))
                        .Select(y => new StudentTaskTeacherResultDto()
                        {
                            Id = y.Id,
                            DetailUrl = url + $"taskId={y.Task_id}&studentId={y.Student_id}",
                            StudentId = y.Student_id,
                            TaskId = y.Task_id,
                            TeacherResult = y.TeacherResult
                        }).ToList()
                }).ToList();

            var studentsGroup = new StudentsGroupDto()
            {
                Id = group.Id,
                Title = group.Title,
                Students = students,
                Courses = courses
            };

            return View(studentsGroup);
        }

        public ActionResult CourseDetail(int courseId)
        {
            var course = dataContext.Courses
                .Find(courseId);

            if (course == null)
                return ResultHelper.EntityNotFound("Course");

            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            if (course.Owner_id != user.Id)
                return ResultHelper.Failed($"Курс {{{courseId}}} не принадлежит текущему пользователю");

            var url = "https://" + HttpContext.Request.Host + "/Teachers/TaskDetail?taskId=";

            var tasks = course.Tasks
                .Select(x => new TaskDto()
                {
                    Id = x.Id,
                    DetailUrl = url + x.Id,
                    MaxResult = x.MaxResult,
                    Description = x.Description,
                    Title = x.Title

                }).ToList();

            var courseDto = new CourseDto()
            {
                Id = course.Id,
                Title = course.Title,
                Name = course.Name,
                Tasks = tasks
            };

            return View(courseDto);
        }

        public ActionResult StudentTaskResult(int taskId, int studentId)
        {
            var student = dataContext.Users.Find(studentId);

            if (student == null)
                return ResultHelper.UserNotFound();

            var task = dataContext.Tasks
                .Include(x => x.Course)
                .FirstOrDefault(x => x.Id == taskId);

            if (task == null)
                return ResultHelper.EntityNotFound("Task");

            var userDto = new UserDto()
            {
                Id = student.Id,
                Title = student.Title
            };

            var tests = task.Tests
                .Select(x => new TestDto()
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToList();

            var testsIds = tests.Select(x => x.Id).ToList();

            var testResults = dataContext.StudentsTestsResults
                .Where(x => x.Student_id == student.Id)
                .Where(x => testsIds.Contains(x.Test_id))
                .Select(x => new StudentTestResultDto()
                {
                    Id = x.Id,
                    Test = new TestDto()
                    {
                        Id = x.Test.Id,
                        Title = x.Test.Title
                    },
                    StudentId = student.Id,
                    State = x.TestState
                }).ToList();

            foreach (var test in tests.Where(x => !testResults.Any(y => y.Test.Id == x.Id)))
            {
                var studentTestResult = new StudentTestResult()
                {
                    Student_id = student.Id,
                    Test_id = test.Id,
                    TestState = dataContext.TestStates.First(x => x.Name == "Failed")
                };

                dataContext.Entry(studentTestResult).State = EntityState.Added;
                dataContext.SaveChanges();

                testResults.Add(new StudentTestResultDto()
                {
                    StudentId = student.Id,
                    Id = studentTestResult.Id,
                    Test = test,
                    State = studentTestResult.TestState
                });
            }

            var taskResult = dataContext.StudentsTaskTeacherResults
                .FirstOrDefault(x => x.Task_id == task.Id && x.Student_id == student.Id);

            if (taskResult == null)
            {
                var now = DateTime.UtcNow;

                taskResult = new StudentTaskTeacherResult()
                {
                    CreationDateTime = now,
                    StateDateTime = now,
                    TaskState = dataContext.TaskStates.First(x => x.Name == "Failed"),
                    Student_id = student.Id,
                    Task_id = task.Id
                };

                dataContext.Entry(taskResult).State = EntityState.Added;
                dataContext.SaveChanges();
            }

            var studentTaskDto = new StudentTaskDto()
            {
                Task = new TaskDto()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Tests = tests,
                    Description = task.Description,
                    MaxResult = task.MaxResult
                },
                TestsResults = testResults,
                TeacherResult = new StudentTaskTeacherResultDto()
                {
                    Id = taskResult.Id,
                    StudentId = student.Id,
                    Student = new UserDto()
                    {
                        Id = student.Id,
                        Title = student.Title,
                        GroupTitle = student.Group.Title
                    },
                    DownloadStudentSolutionUrl = "https://" + this.HttpContext.Request.Host +
                        $"/Teachers/DownloadStudentSolution?studentResultId={taskResult.Id}",
                    TaskId = task.Id,
                    SolutionLoadDateTime = taskResult.SolutionLoadDateTime,
                    SuccessTestsCount = testResults.Count(x => x.State.Name == "Success"),
                    TeacherResult = taskResult.TeacherResult
                }
            };

            return View(studentTaskDto);
        }

        public ActionResult DownloadStudentSolution(int studentResultId)
        {
            var studentResult = dataContext.StudentsTaskTeacherResults.Find(studentResultId);

            if (studentResult == null)
                return ResultHelper.EntityNotFound("StudentTaskTeacherResult");

            var file = new FileInfo(studentResult.StudentFilePath);

            var stream = file.OpenRead();

            return new FileStreamResult(stream, $"application/{file.Extension}")
            {
                FileDownloadName = file.Name
            };

        }

        [HttpGet]
        public ActionResult CreateStudentsGroup(int userId)
        {
            var user = dataContext.Users.Find(userId);

            if (user == null)
                return ResultHelper.UserNotFound();

            return View(new StudentsGroupViewModel() { OwnerId = user.Id });
        }

        [HttpPost]
        public ActionResult CreateStudentsGroup(StudentsGroupViewModel model)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            var groupToCreate = new StudentsGroup()
            {
                Title = model.Title,
                Owner_id = model.OwnerId
            };

            dataContext.Entry(groupToCreate).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect($"/Users/Lk?userId={user.Id}");
        }

        [HttpGet]
        public ActionResult CreateCourse(int userId)
        {
            var user = dataContext.Users.Find(userId);

            if (user == null)
                return ResultHelper.UserNotFound();

            return View(new CourseViewModel() { OwnerId = user.Id });
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseViewModel model)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var courseToCreate = new Course()
            {
                Title = model.Title,
                Name = model.Title,
                Owner_id = model.OwnerId
            };

            dataContext.Entry(courseToCreate).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect($"/Users/Lk?userId={user.Id}");
        }

        [HttpGet]
        public ActionResult EditTask(int taskId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var task = dataContext.Tasks.Find(taskId);

            if (task == null)
                return ResultHelper.EntityNotFound("Task");

            var courses = dataContext.Courses
                .Where(x => x.Owner_id == user.Id)
                .Select(x => new SelectListItem()
                {
                    Value = $"{x.Id}",
                    Text = x.Title
                }).ToList();

            var programmingLanguages = dataContext.ProgrammingLanguages
                .Select(x => new SelectListItem()
                {
                    Value = $"{x.Id}",
                    Text = x.Title
                }).ToList();

            var taskViewModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                MaxResult = task.MaxResult,
                CourseId = task.Course_id,
                Courses = courses,
                Deadline = task.Deadline,
                MinimumTestsPercent = task.MinimumTestsPercent,
                ProgrammingLanguageId = task.ProgrammingLanguage_id,
                ProgrammingLanguages = programmingLanguages
            };

            return View(taskViewModel);
        }

        [HttpPost]
        public ActionResult EditTask(TaskViewModel model)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var task = dataContext.Tasks.Find(model.Id);

            if (task == null)
                return ResultHelper.EntityNotFound("Task");

            task.Title = model.Title;
            task.Description = model.Description;
            task.MaxResult = model.MaxResult;
            task.Course_id = model.CourseId;
            task.Deadline = model.Deadline;
            task.MinimumTestsPercent = model.MinimumTestsPercent;
            task.ProgrammingLanguage_id = model.ProgrammingLanguageId;

            dataContext.Entry(task).State = EntityState.Modified;
            dataContext.SaveChanges();

            return Redirect($"/Teachers/CourseDetail?courseId={task.Course_id}");
        }

        [HttpGet]
        public ActionResult CreateTask(int courseId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var course = dataContext.Courses.Find(courseId);

            if (course == null)
                return ResultHelper.EntityNotFound("Course");

            var programmingLanguages = dataContext.ProgrammingLanguages
                .Select(x => new SelectListItem()
                {
                    Value = $"{x.Id}",
                    Text = x.Title
                }).ToList();

            var taskViewModel = new TaskViewModel()
            {
                CourseId = courseId,
                ProgrammingLanguages = programmingLanguages
            };

            return View(taskViewModel);
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel model, int courseId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var task = new Models.Task() {
                Title = model.Title,
                Description = model.Description,
                MaxResult = model.MaxResult,
                Deadline = model.Deadline,
                Course_id = courseId,
                MinimumTestsPercent = model.MinimumTestsPercent,
                ProgrammingLanguage_id = model.ProgrammingLanguageId
            };

            dataContext.Entry(task).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect($"/Teachers/CourseDetail?courseId={task.Course_id}");
        }

        public ActionResult TaskDetail(int taskId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var task = dataContext.Tasks
                .Include(x => x.Course)
                .FirstOrDefault(x => x.Id == taskId);

            if (task == null)
                return ResultHelper.EntityNotFound("Task");

            if (task.Course.Owner_id != user.Id)
                return ResultHelper.Failed("Данный пользователь не является владельцем курса");

            var tests = task.Tests
                .Select(x => new TestDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    FileName = x.TestFilePath != null ? new FileInfo(x.TestFilePath).Name : "",
                    DetailUrl = "https://" + HttpContext.Request.Host + "/Teachers/TestDetail?id=" + x.Id
                }).ToList();

            var taskDto = new TaskDto()
            {
                Id = task.Id,
                Title = task.Title,
                CourseId = task.Course_id,
                CourseTitle = task.Course.Title,
                Description = task.Description,
                MaxResult = task.MaxResult,
                Deadline = task.Deadline,
                MinimunTestsPercent = task.MinimumTestsPercent,
                Tests = tests
            };

            return View(taskDto);
        }

        [HttpGet]
        public ActionResult CreateTest(int taskId)
        {
            var task = dataContext.Tasks.Find(taskId);

            if (task == null)
                return ResultHelper.EntityNotFound("Task");

            return View("CreateTest", new TestViewModel() { Tasks = new List<SelectListItem>() { new SelectListItem() { Text = "", Value = $"{taskId}" } } });
        }

        [HttpPost]
        public ActionResult CreateTest(TestViewModel model)
        {
            var task = dataContext.Tasks
                .Include(x => x.Course)
                .ThenInclude(x => x.Owner)
                .SingleOrDefault(x => x.Id == model.TaskId);

            if (task == null)
                return ResultHelper.Failed($"Задачи #{model.TaskId} не существует.");

            var existTest = dataContext.Set<Test>()
                .Where(x => x.Task_id == task.Id)
                .FirstOrDefault(x => x.Title == model.Title);
            
            if(existTest != null)
                return ResultHelper.Failed($"Тест с таким названием уже существует");

            var testToCreate = new Test()
            {
                Title = model.Title,
                InputValue = model.InputValue,
                ExpectedResult = model.ExpectedResult,
                Task_id = task.Id,
                Description = model.Description
            };

            if (model.TestFile != null)
            {
                string path = appEnvironment.ContentRootPath + $"/AppData/Files/Tests/{task.Course.Owner.Title}/{task.Course.Title}/{task.Title}/";
                var directory = Directory.CreateDirectory(path);

                //Файл называем так же, как задачу
                var fileName = model.Title + Path.GetExtension(model.TestFile.FileName);

                using (var fileStream = new FileStream(path + fileName, FileMode.Create))
                {
                    model.TestFile.CopyTo(fileStream);
                }

                testToCreate.TestFilePath = path + fileName;
            }

            dataContext.Entry(testToCreate).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect($"/Teachers/TaskDetail?taskId={task.Id}");
        }

        [HttpGet]
        public ActionResult EditTest(int testId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var test = dataContext.Tests
                .FirstOrDefault(x => x.Id == testId);

            if (test == null)
                return ResultHelper.EntityNotFound("Test");

            var testViewModel = new TestViewModel()
            {
                Id = test.Id,
                Title = test.Title,
                FileName = new FileInfo(test.TestFilePath).Name,
                TaskId = test.Task_id,
                Description = test.Description
            };

            return View(testViewModel);
        }

        [HttpPost]
        public ActionResult EditTest(TestViewModel model)
        {
            var task = dataContext.Tasks
                .Include(x => x.Course)
                .ThenInclude(x => x.Owner)
                .SingleOrDefault(x => x.Id == model.TaskId);

            if (task == null)
                return ResultHelper.Failed($"Задачи #{model.TaskId} не существует.");

            string path = appEnvironment.ContentRootPath + $"/AppData/Files/Tests/{task.Course.Owner.Title}/{task.Course.Title}/{task.Title}/";
            var directory = Directory.CreateDirectory(path);

            using (var fileStream = new FileStream(path + model.TestFile.FileName, FileMode.Create))
            {
                model.TestFile.CopyTo(fileStream);
            }

            var testToCreate = new Test()
            {
                Title = model.Title,
                TestFilePath = path + model.TestFile.FileName,
                Task_id = task.Id,
                Description = model.Description
            };

            dataContext.Entry(testToCreate).State = EntityState.Added;
            dataContext.SaveChanges();

            return Redirect($"/Teachers/TaskDetail?taskId={task.Id}");
        }

        [HttpGet]
        public ActionResult EditTeacherResult(int teacherResultId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            var teacherResult = dataContext.StudentsTaskTeacherResults
                .Find(teacherResultId);

            if (teacherResult == null)
                return ResultHelper.EntityNotFound("StudentTaskTeacherResult");

            var teacherResultViewModel = new TeacherResultViewModel()
            {
                Id = teacherResult.Id,
                MaxResult = teacherResult.Task.MaxResult,
                TeacherResult = teacherResult.TeacherResult ?? 0
            };

            return View(teacherResultViewModel);
        }

        [HttpPost]
        public ActionResult EditTeacherResult(TeacherResultViewModel model)
        {
            var teacherResult = dataContext.StudentsTaskTeacherResults
                .Find(model.Id);

            if (teacherResult == null)
                return ResultHelper.EntityNotFound($"StudentTaskTeacherResult");

            teacherResult.TeacherResult = model.TeacherResult;

            dataContext.Entry(teacherResult).State = EntityState.Modified;
            dataContext.SaveChanges();

            return Redirect($"/Teachers/StudentTaskResult?taskId={teacherResult.Task_id}&studentId={teacherResult.Student_id}");
        }

        [HttpGet]
        public JsonResult AddStudentToGroupGenerateLink(int studentGroupId)
        {
            var studentGroup = dataContext.StudentsGroups.Find(studentGroupId);
            if(studentGroup == null)
            {
                return Json(new { Success = true, Reason = "Не найдена студенческая группа" });
            }

            var linkCommandString = $"AddStudentToGroup_{studentGroup.Id}_actualDateTime={Convert.ToBase64String(Encoding.UTF8.GetBytes(DateTime.UtcNow.AddDays(1).ToString()))}";
            if (!CryptoHelper.TryEncrypt(linkCommandString, out var encryptedCommandString))
            {
                return Json(new { Success = true, Reason = "Не удалось зашифровать ссылку" });
            }

            var link = "https://" + HttpContext.Request.Host + $"/Students/AddStudentToGroup?hash={encryptedCommandString}";

            return Json(new { Success = true, Link = link });
        }

        [HttpGet]
        public ActionResult AddCourseToStudentsGroup(int studentsGroupId)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            if (user.Role != UserRole.Teacher(dataContext))
                return ResultHelper.Failed("Только преподаватели могут добавлять курсы в группы");

            var studentsGroup = dataContext.StudentsGroups.Find(studentsGroupId);
            if (studentsGroup == null)
                return ResultHelper.EntityNotFound("StudentsGroup");

            if (studentsGroup.Owner_id != user.Id)
                return ResultHelper.Failed("Нет прав к текущей группе");

            var courses = dataContext.Courses
                .Where(x => x.Owner_id == user.Id)
                .Select(x => new SelectListItem()
                {
                    Value = $"{x.Id}",
                    Text = x.Title
                }).ToList();

            var studentsGroupCourseViewModel = new StudentsGroupCourseViewModel()
            {
                StudentsGroupId = studentsGroup.Id,
                Courses = courses
            };

            return View(studentsGroupCourseViewModel);
        }

        [HttpPost]
        public ActionResult AddCourseToStudentsGroup(StudentsGroupCourseViewModel model)
        {
            var user = TaskChecker.Models.User.Get(dataContext, HttpContext);

            if (user == null)
                return ResultHelper.UserNotFound();

            if (user.Role != UserRole.Teacher(dataContext))
                return ResultHelper.Failed("Только преподаватели могут добавлять курсы в группы");

            var studentsGroup = dataContext.StudentsGroups.Find(model.StudentsGroupId);
            if (studentsGroup == null)
                return ResultHelper.EntityNotFound("StudentsGroup");

            var course = dataContext.Courses.Find(model.CourseId);
            if (course == null)
                return ResultHelper.EntityNotFound("Course");

            if (studentsGroup.Owner_id != user.Id)
                return ResultHelper.Failed("Нет прав к указанной группе");

            if (course.Owner_id != user.Id)
                return ResultHelper.Failed("Нет прав к указанному курсу");

            var studentsGroupCourseToCreate = new StudentsGroupCourse()
            {
                StudentsGroup_id = studentsGroup.Id,
                Course_id = course.Id
            };

            dataContext.Entry(studentsGroupCourseToCreate).State = EntityState.Added;

            //Добавляем все результаты студентов по курсу
            var taskStateFailed = TaskState.Failed(dataContext);

            foreach(var student in studentsGroup.Students)
            {
                foreach (var task in course.Tasks)
                {
                    var studentResult = new StudentTaskTeacherResult()
                    {
                        CreationDateTime = DateTime.UtcNow,
                        StateDateTime = DateTime.UtcNow,
                        Student_id = student.Id,
                        TaskState_id = taskStateFailed.Id,
                        Task_id = task.Id,
                    };

                    dataContext.Entry(studentResult).State = EntityState.Added;
                }
            }

            dataContext.SaveChanges();

            return Redirect($"/Teachers/StudentsGroupDetail?groupId={studentsGroup.Id}");
        }

    }
}

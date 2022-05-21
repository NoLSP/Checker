using TaskChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskChecker.ViewModels
{
    public class StudentsGroupCourseViewModel
    {
        public int StudentsGroupId { get; set; }
        public int CourseId { get; set; }

        public List<SelectListItem> Courses { get; set; }
    }
}

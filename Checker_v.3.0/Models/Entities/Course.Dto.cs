using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checker_v._3._0.Models
{
    public class CourseDto
    {
        public int Id;
        public string Title;
        public string Name;
        public string DetailUrl;
        public List<TaskDto> Tasks;
        public List<StudentTaskTeacherResultDto> TasksResults;
    }
}

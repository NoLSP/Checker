using TaskChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.ViewModels
{
    public class TeacherViewModel
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Email;
        public IEnumerable<StudentsGroupDto> StudentsGroups;
        public IEnumerable<CourseDto> Courses;
    }
}

using TaskChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.ViewModels
{
    public class TeacherResultViewModel
    {
        public int Id { get; set; }

        public int MaxResult;
        public int TeacherResult { get; set; }

        public int StudentId;
        public int TaskId;
    }
}

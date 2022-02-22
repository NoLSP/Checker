using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.ViewModels
{
    public class CourseViewModel
    {
        public string Title { get; set; }
        
        public int OwnerId { get; set; }
    }
}

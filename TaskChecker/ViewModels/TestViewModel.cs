using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public IFormFile TestFile { get;set; }

        public string FileName { get; set; }
        public string InputValue { get; set; }
        public string ExpectedResult { get; set; }

        public List<SelectListItem> Tasks;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checker_v._3._0.Models
{
    public class StudentDto
    {
        public int Id;
        public string Email;
        public string FullName;
        public IEnumerable<string> GroupsTitles;
    }
}

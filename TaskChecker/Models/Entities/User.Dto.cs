using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class UserDto
    {
        public int Id;
        public int GroupId;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Title;
        public string Email;
        public string GroupTitle;
        public int Points;
        public int TotalPoints;
        public List<TaskDto> Tasks;
        public string DetailUrl;
    }
}

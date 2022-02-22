﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class StudentTestResultDto
    {
        public int Id;
        public UserDto Student;
        public int StudentId;
        public TestDto Test;
        public int TestId;
        public TestState State;
    }
}

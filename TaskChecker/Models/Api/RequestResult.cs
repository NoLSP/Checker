using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class RequestResult
    {
        public bool Success { get; set; }
        public string Reason { get; set; }
        public bool TestResult { get; set; }
    }
}

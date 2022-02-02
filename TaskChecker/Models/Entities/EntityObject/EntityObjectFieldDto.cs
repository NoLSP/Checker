using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class EntityObjectFieldDto
    {
        public Type Type;
        public string Title;
        public string Name;
        public object Value;
        public List<SelectListItem> Values;
        public string Url;
        public string InputType;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models.Attributes
{
    public class InputType : System.Attribute
    {
        public string Name { get; set; }

        public InputType(string Name)
        {
            this.Name = Name;
        }
    }
}

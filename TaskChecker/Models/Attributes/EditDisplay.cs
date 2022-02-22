using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models.Attributes
{
    public class EditDisplay : System.Attribute
    {
        public string Name { get; set; }

        public EditDisplay(string Name)
        {
            this.Name = Name;
        }
    }
}

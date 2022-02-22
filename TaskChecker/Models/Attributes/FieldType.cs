using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models.Attributes
{
    public enum FieldTypes
    {
        Int,
        String,
        Decimal,
        File,
        Link,
        List,
        DateTime
    }

    public class FieldType : System.Attribute
    {
        public FieldTypes Name { get; set; }

        public FieldType(FieldTypes Name)
        {
            this.Name = Name;
        }
    }
}

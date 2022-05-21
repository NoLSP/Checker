using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models.Attributes
{
    public class Order : System.Attribute
    {
        public int OrderNumber { get; set; }

        public Order(int orderNumber)
        {
            this.OrderNumber = orderNumber;
        }
    }
}

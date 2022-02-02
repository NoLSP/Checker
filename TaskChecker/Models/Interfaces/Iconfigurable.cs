using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    interface IConfigurable
    {
        public string RouteList();
        public string RouteCreate();
        public string RouteDelete();
        public string RouteDetail();
    }
}

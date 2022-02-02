using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class EntityObjectDetailDto
    {
        public int EntityId;
        public string EntityTitle;
        public string EntityName;
        public List<EntityObjectFieldDto> Fields;
    }
}

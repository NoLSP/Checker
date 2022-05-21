using System.Collections.Generic;

namespace TaskChecker.Models
{
    public class EntityObjectListDto
    {
        public string Title;
        public string EntityName;
        public List<EntityObjectFieldDto> Head;
        public List<List<EntityObjectFieldDto>> Entities;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Checker_v._3._0.Models
{
    public class EntityObject : IConfigurable
    {
        public EntityObject() { }

        public static List<string> SystemEntiies = new List<string>()
        {
            "User",
            "UserRole",
            "StudentsGroup",
            "Task",
            "TasksGroup",
            "Test",
            "StudentTestResult",
            "StudentTaskTeacherResult",
            "TestState"
        };

        public string RouteList() 
        {
            var type = this.GetType().Name;
            return $"/EntityObjects/{type}/List";
        }

        public string RouteCreate()
        {
            var type = this.GetType().Name;
            return $"/EntityObjects/{type}/Create";
        }

        public string RouteDelete()
        {
            var type = this.GetType().Name;
            return $"/EntityObjects/{type}/Delete";
        }

        public IQueryable AsIQueryable(DataContext dataContext, Type type)
        {
            return dataContext.Set(type) as IQueryable;
        }

        public static EntityObject GetInstance(DataContext dataContext, Type entityType)
        {
            ConstructorInfo constructor = entityType.GetConstructor(new Type[] { Type.GetType("Checker_v._3._0.Models.DataContext") });
            EntityObject instance = constructor.Invoke(new object[] { dataContext }) as EntityObject;
            return instance;
        }
    }
}

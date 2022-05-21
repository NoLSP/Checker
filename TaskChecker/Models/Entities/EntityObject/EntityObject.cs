using TaskChecker.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace TaskChecker.Models
{
    public class EntityObject : IConfigurable
    {
        public EntityObject() { }

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

        public string RouteDetail()
        {
            var type = this.GetType().Name;
            return $"/EntityObjects/{type}/Detail/{this.Id}";
        }

        public IQueryable AsIQueryable(DataContext dataContext, Type type)
        {
            return dataContext.Set(type) as IQueryable;
        }

        public static EntityObject GetInstance(DataContext dataContext, Type entityType)
        {
            ConstructorInfo constructor = entityType.GetConstructor(new Type[] { Type.GetType("TaskChecker.Models.DataContext") });
            EntityObject instance = constructor.Invoke(new object[] { dataContext }) as EntityObject;
            return instance;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ListDisplay("Id")]
        [DetailDisplay("Id")]
        [NotNull]
        [FieldType(FieldTypes.Int)]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        [Order(1)]
        public int Id { get; set; }
    }
}

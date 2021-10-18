using Checker_v._3._0.Helpers;
using Checker_v._3._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checker_v._3._0.Controllers
{
    public class EntityObjectsController : Controller
    {
        private DataContext dataContext;
        public EntityObjectsController(DataContext context)
        {
            dataContext = context;
        }

        [Route("/EntityObjects/{entityType}/List")]
        public ActionResult List(string entityType)
        {
            var type = Type.GetType($"Checker_v._3._0.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var fields = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is DisplayAttribute))
                .Select(p => new 
                { 
                    FieldName = p.Name,
                    FieldType = p.PropertyType,
                    FieldDisplayName = (p.GetCustomAttributes(false).First(attr => attr is DisplayAttribute) as DisplayAttribute).Name
                });

            var head = fields.Select(x => x.FieldDisplayName)
                .ToList();

            var query = (IQueryable)type.GetMethod("AsIQueryable").Invoke(EntityObject.GetInstance(dataContext, type), new object[] { dataContext, type });

            var data = query.Cast<EntityObject>().ToList();
            var resultData = new List<List<EntityFieldDto>>();

            foreach(var entity in data)
            {
                var dtoEntity = new List<EntityFieldDto>();
                foreach(var field in fields)
                {
                    if (field.FieldType.Name == "Int32")
                    {
                        dtoEntity.Add(new EntityFieldDto()
                        {
                            Type = field.FieldType,
                            Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                            Url = null
                        });
                    }
                    else if (field.FieldType.Name == "String")
                    {
                        dtoEntity.Add(new EntityFieldDto()
                        {
                            Type = field.FieldType,
                            Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                            Url = null
                        });
                    }else if (field.FieldType.IsGenericType && field.FieldType.Name == "List`1")
                    {
                        dynamic items = (dynamic)entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);
                        var values = new List<EntityFieldDto>();
                        foreach(var item in items)
                        {
                            var url = EntityObject.GetInstance(dataContext, item.GetType()).RouteList();
                            values.Add(new EntityFieldDto() 
                            { 
                                Type = item.GetType(),
                                Value = item.GetType().GetProperty("Title").GetValue(item, null),
                                Url = url
                            });
                        }
                        dtoEntity.Add(new EntityFieldDto()
                        {
                            Type = typeof(List<EntityObject>),
                            Value = values,
                        });
                    }
                    else if (EntityObject.SystemEntiies.Contains(field.FieldType.Name))
                    {
                        var url = EntityObject.GetInstance(dataContext, field.FieldType).RouteList();
                        var fieldValue = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);
                        dtoEntity.Add(new EntityFieldDto()
                        {
                            Type = field.FieldType,
                            Value = fieldValue.GetType().GetProperty("Title").GetValue(fieldValue, null),
                            Url = "https://" + HttpContext.Request.Host + url
                        });
                    }
                }
                resultData.Add(dtoEntity);
            }

            return View(new EntityObjectListDto() { 
                Head = head,
                Entities = resultData
            });
        }
    }
}

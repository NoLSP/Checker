using TaskChecker.Helpers;
using TaskChecker.Models;
using TaskChecker.Models.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace TaskChecker.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EntityObjectsController : Controller
    {
        private DataContext dataContext;
        private IWebHostEnvironment appEnvironment;

        public EntityObjectsController(DataContext context, IWebHostEnvironment appEnvironment)
        {
            dataContext = context;
            this.appEnvironment = appEnvironment;
        }

        [Route("/EntityObjects/{entityType}/List")]
        public ActionResult List(string entityType)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entityDisplayName = (type.GetCustomAttributes(false).First(attr => attr is ListDisplay) as ListDisplay).Name;

            var fields = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is ListDisplay))
                .Select(p => new 
                { 
                    FieldName = p.Name,
                    FieldDisplayName = (p.GetCustomAttributes(false).First(attr => attr is ListDisplay) as ListDisplay).Name,
                    FieldNotNull = p.GetCustomAttributes(false).Any(attr => attr is NotNull),
                    FieldType = (p.GetCustomAttributes(false).First(attr => attr is FieldType) as FieldType).Name,
                });

            var head = fields.Select(x => x.FieldDisplayName)
                .ToList();

            var query = (IQueryable)type.GetMethod("AsIQueryable").Invoke(EntityObject.GetInstance(dataContext, type), new object[] { dataContext, type });

            var data = query.Cast<EntityObject>().ToList();
            var resultData = new List<List<EntityObjectFieldDto>>();

            foreach(var entity in data)
            {
                var dtoEntity = new List<EntityObjectFieldDto>();
                foreach(var field in fields)
                {
                    if (field.FieldType == FieldTypes.Int)
                    {
                        dtoEntity.Add(new EntityObjectFieldDto()
                        {
                            Name = field.FieldName,
                            Title = field.FieldDisplayName,
                            Type = field.FieldType,
                            Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                            Url = null
                        });
                    }
                    else if (field.FieldType == FieldTypes.String)
                    {
                        var url = (string)null;
                        if (field.FieldName == "Title")
                            url = "https://" + HttpContext.Request.Host + entity.RouteDetail();

                        dtoEntity.Add(new EntityObjectFieldDto()
                        {
                            Name = field.FieldName,
                            Title = field.FieldDisplayName,
                            Type = field.FieldType,
                            Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                            Url = url
                        });
                    }
                    else if (field.FieldType == FieldTypes.List)
                    {
                        dynamic items = (dynamic)entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);

                        dtoEntity.Add(new EntityObjectFieldDto()
                        {
                            Name = field.FieldName,
                            Title = field.FieldDisplayName,
                            Type = FieldTypes.List,
                            Value = items.Count,
                        });
                    }
                    else if (field.FieldType == FieldTypes.Link)
                    {
                        var fieldValue = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);
                        var url = fieldValue == null ? "" : (fieldValue as EntityObject).RouteDetail();
                        dtoEntity.Add(new EntityObjectFieldDto()
                        {
                            Name = field.FieldName,
                            Title = field.FieldDisplayName,
                            Type = field.FieldType,
                            Value = fieldValue == null ? "-" : fieldValue.GetType().GetProperty("Title").GetValue(fieldValue, null),
                            Url = "https://" + HttpContext.Request.Host + url
                        });
                    }
                    else if (field.FieldType == FieldTypes.File)
                    {
                        string fileName = "-";
                        string url = null;

                        var filePath = (string)entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);

                        if(filePath != null)
                        {
                            var file = new FileInfo(filePath);
                            fileName = file.Name;
                            url = $"https://{HttpContext.Request.Host}/EntityObjects/{entityType}/Download?id={entity.Id}&attributeName={field.FieldName}";
                        }

                        dtoEntity.Add(new EntityObjectFieldDto()
                        {
                            Name = field.FieldName,
                            Title = field.FieldDisplayName,
                            Type = field.FieldType,
                            Value = fileName,
                            Url = url
                        });
                    }
                }
                resultData.Add(dtoEntity);
            }

            return View(new EntityObjectListDto() { 
                EntityName = entityType,
                Title = entityDisplayName,
                Head = head,
                Entities = resultData
            });
        }

        [Route("/EntityObjects/{entityType}/Detail/{id}")]
        public ActionResult Detail(string entityType, int id)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var fields = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is DetailDisplay))
                .Select(p => new
                {
                    FieldName = p.Name,
                    FieldDisplayName = (p.GetCustomAttributes(false).First(attr => attr is DetailDisplay) as DetailDisplay).Name,
                    FieldNotNull = p.GetCustomAttributes(false).Any(attr => attr is NotNull),
                    FieldType = (p.GetCustomAttributes(false).First(attr => attr is FieldType) as FieldType).Name,
                });

            var entity = (EntityObject)dataContext.Set(type).Find(id);

            if(entity == null)
                return ResultHelper.EntityNotFound($"{id}");

            var entityFields = new List<EntityObjectFieldDto>();
            foreach (var field in fields)
            {
                if (field.FieldType == FieldTypes.Int)
                {
                    entityFields.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                        Url = null
                    });
                }
                else if (field.FieldType == FieldTypes.String)
                {
                    entityFields.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                        Url = null
                    });
                }
                else if (field.FieldType == FieldTypes.List)
                {
                    dynamic items = (dynamic)entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);

                    entityFields.Add(new EntityObjectFieldDto()
                    {
                        Type = FieldTypes.List,
                        Title = field.FieldDisplayName,
                        Value = items.Count,
                    });
                }
                else if (field.FieldType == FieldTypes.Link)
                {
                    var fieldValue = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);
                    var url = fieldValue == null ? "" : (fieldValue as EntityObject).RouteDetail();
                    entityFields.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Value = fieldValue == null ? "" : fieldValue.GetType().GetProperty("Title").GetValue(fieldValue, null),
                        Url = "https://" + HttpContext.Request.Host + url
                    });
                }
                else if (field.FieldType == FieldTypes.File)
                {
                    var fieldValue = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);
                    var url = $"https://{HttpContext.Request.Host}/EntityObjects/{entityType}/Download?id={entity.Id}&attributeName={field.FieldName}";

                    entityFields.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Value = fieldValue == null ? "" : new FileInfo((string)fieldValue).Name,
                        Url = fieldValue == null ? null : url
                    });
                }
            }

            var entityTitle = (string)null;
            if (entity.GetType().GetProperty("Title") != null)
                entityTitle = (string)entity.GetType().GetProperty("Title").GetValue(entity, null);
            else
                entityTitle = entityType + " #" + entity.GetType().GetProperty("Id").GetValue(entity, null).ToString();

            return View(new EntityObjectDetailDto()
            {
                EntityId = id,
                EntityName = entityType,
                EntityTitle = entityTitle,
                Fields = entityFields
            });
        }

        [HttpGet]
        [Route("/EntityObjects/{entityType}/Create")]
        public ActionResult Create(string entityType)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entityDisplayName = (type.GetCustomAttributes(false).First(attr => attr is EditDisplay) as EditDisplay).Name;

            var fields = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is EditDisplay))
                .Select(p => new
                {
                    FieldName = p.PropertyType.BaseType.Name == "EntityObject" ?
                                (p.GetCustomAttributes(false).First(attr => attr is ForeignKeyAttribute) as ForeignKeyAttribute).Name :
                                p.Name,
                    FieldEntityType = p.PropertyType,
                    FieldDisplayName = (p.GetCustomAttributes(false).First(attr => attr is EditDisplay) as EditDisplay).Name,
                    FieldInputType = (p.GetCustomAttributes(false).First(attr => attr is InputType) as InputType).Name,
                    FieldNotNull = p.GetCustomAttributes(false).Any(attr => attr is NotNull),
                    FieldType = (p.GetCustomAttributes(false).First(attr => attr is FieldType) as FieldType).Name,
                });

            var dtoEntity = new List<EntityObjectFieldDto>();
            foreach (var field in fields)
            {
                if (field.FieldType == FieldTypes.Int)
                {
                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Name = field.FieldName,
                        Title = field.FieldDisplayName,
                        Type = field.FieldType,
                        InputType = field.FieldInputType
                    });
                }
                else if (field.FieldType == FieldTypes.String)
                {
                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Name = field.FieldName,
                        Title = field.FieldDisplayName,
                        Type = field.FieldType,
                        InputType = field.FieldInputType
                    });
                }
                else if (field.FieldType == FieldTypes.Link)
                {
                    var items = ((IQueryable<dynamic>)dataContext.Set(field.FieldEntityType))
                        .ToList()
                        .Select(x => new SelectListItem()
                        {
                            Value = $"{x.Id}",
                            Text = x.Title
                        }).ToList();
                    
                    if(!field.FieldNotNull)
                        items.Insert(0, new SelectListItem(){Text = "-", Value = null});

                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Name = field.FieldName,
                        InputType = field.FieldInputType,
                        Values = items
                    });
                }
                else if (field.FieldType == FieldTypes.File)
                {
                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Name = field.FieldName,
                        InputType = field.FieldInputType
                    });
                }
            }

            ViewData["Title"] = "Создать";

            return View("_CreateForm",new EntityObjectEditDto()
            {
                EntityName = entityDisplayName,
                Fields = dtoEntity
            });
        }

        [HttpPost]
        [Route("/EntityObjects/{entityType}/Create")]
        public ActionResult Create(string entityType, [FromForm] string fields)
        {
            var fieldsData = JArray.Parse(fields);
            var filesData = HttpContext.Request.Form.Files;

            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entity = EntityObject.GetInstance(dataContext, type);

            var fieldTypes = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is EditDisplay))
                .ToDictionary(p => p.PropertyType.BaseType.Name == "EntityObject" ? 
                                   (p.GetCustomAttributes(false).First(attr => attr is ForeignKeyAttribute) as ForeignKeyAttribute).Name :
                                   p.Name, p => p.PropertyType);

            foreach (JObject field in fieldsData)
            {
                var fieldName = (string)field.GetValue("FieldName");
                var fieldType = fieldTypes[fieldName];
                var jFieldValue = field.GetValue("FieldValue");

                if(fieldName.EndsWith("_id"))
                {
                    entity.GetType().GetProperty(fieldName).SetValue(entity, (int)jFieldValue);
                }
                else
                {
                    entity.GetType().GetProperty(fieldName).SetValue(entity, Convert.ChangeType(jFieldValue, fieldType));
                } 
            }

            dataContext.Entry(entity).State = EntityState.Added;
            dataContext.SaveChanges();

            foreach (var fileData in filesData)
            {
                string path = appEnvironment.ContentRootPath + $"/AppData/Files/{entityType}/{entity.Id}/{fileData.Name}/";
                var directory = Directory.CreateDirectory(path);

                using (var fileStream = new FileStream(path + fileData.FileName, FileMode.Create))
                {
                    fileData.CopyTo(fileStream);
                }

                entity.GetType().GetProperty(fileData.Name).SetValue(entity, path + fileData.FileName);
            }

            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();

            return ResultHelper.Successed();
        }

        [HttpGet]
        [Route("/EntityObjects/{entityType}/Edit/{id}")]
        public ActionResult Edit(string entityType, int id)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entity = (EntityObject)dataContext.Set(type).Find(id);

            if (entity == null)
                return ResultHelper.EntityNotFound($"{id}");

            var entityDisplayName = (type.GetCustomAttributes(false).First(attr => attr is EditDisplay) as EditDisplay).Name;

            var fields = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is EditDisplay))
                .Select(p => new
                {
                    FieldName = p.PropertyType.BaseType.Name == "EntityObject" ?
                                (p.GetCustomAttributes(false).First(attr => attr is ForeignKeyAttribute) as ForeignKeyAttribute).Name :
                                p.Name,
                    FieldEntityType = p.PropertyType,
                    FieldDisplayName = (p.GetCustomAttributes(false).First(attr => attr is EditDisplay) as EditDisplay).Name,
                    FieldInputType = (p.GetCustomAttributes(false).First(attr => attr is InputType) as InputType).Name,
                    FieldNotNull = p.GetCustomAttributes(false).Any(attr => attr is NotNull),
                    FieldType = (p.GetCustomAttributes(false).First(attr => attr is FieldType) as FieldType).Name,
                });

            var dtoEntity = new List<EntityObjectFieldDto>();
            foreach (var field in fields)
            {
                if (field.FieldType == FieldTypes.Int)
                {
                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Name = field.FieldName,
                        Title = field.FieldDisplayName,
                        Type = field.FieldType,
                        InputType = field.FieldInputType,
                        Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                    });
                }
                else if (field.FieldType == FieldTypes.String)
                {
                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Name = field.FieldName,
                        Title = field.FieldDisplayName,
                        Type = field.FieldType,
                        InputType = field.FieldInputType,
                        Value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null),
                    });
                }
                else if (field.FieldType == FieldTypes.Link)
                {
                    var items = ((IQueryable<dynamic>)dataContext.Set(field.FieldEntityType))
                        .ToList()
                        .Select(x => new SelectListItem()
                        {
                            Value = $"{x.Id}",
                            Text = x.Title
                        }).ToList();

                    if(!field.FieldNotNull)
                        items.Insert(0, new SelectListItem(){Text = "-", Value = null});

                    var value = entity.GetType().GetProperty(field.FieldName).GetValue(entity, null);

                    var selectedItem = items.FirstOrDefault(x => x.Value == $"{value}");
                    if(selectedItem != null)
                        selectedItem.Selected = true;

                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Name = field.FieldName,
                        InputType = field.FieldInputType,
                        Values = items
                    });
                }
                else if (field.FieldType == FieldTypes.File)
                {
                    var fieldValue = (string)null;
                    if (entity.GetType().GetProperty(field.FieldName).GetValue(entity, null) != null)
                        fieldValue = new FileInfo((string)entity.GetType().GetProperty(field.FieldName).GetValue(entity, null)).Name;

                    dtoEntity.Add(new EntityObjectFieldDto()
                    {
                        Type = field.FieldType,
                        Title = field.FieldDisplayName,
                        Name = field.FieldName,
                        InputType = field.FieldInputType,
                        Value = fieldValue,
                    });
                }
            }

            ViewData["Title"] = "Редактировать";

            return View("_CreateForm", new EntityObjectEditDto()
            {
                EntityName = entityDisplayName,
                Fields = dtoEntity
            });
        }

        [HttpPost]
        [Route("/EntityObjects/{entityType}/Edit/{id}")]
        public ActionResult Edit(string entityType, int id, [FromForm] string fields)
        {
            var fieldsData = JArray.Parse(fields);
            var filesData = HttpContext.Request.Form.Files;

            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entity = (EntityObject)dataContext.Set(type).Find(id);

            if (entity == null)
                return ResultHelper.EntityNotFound($"{id}");

            var fieldTypes = type.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(attr => attr is EditDisplay))
                .ToDictionary(p => p.PropertyType.BaseType.Name == "EntityObject" ?
                                   (p.GetCustomAttributes(false).First(attr => attr is ForeignKeyAttribute) as ForeignKeyAttribute).Name :
                                   p.Name, p => p.PropertyType);

            foreach (JObject field in fieldsData)
            {
                var fieldName = (string)field.GetValue("FieldName");
                var fieldType = fieldTypes[fieldName];
                var jFieldValue = field.GetValue("FieldValue");

                if (fieldName.EndsWith("_id"))
                {
                    if((string)jFieldValue == "-")
                        entity.GetType().GetProperty(fieldName).SetValue(entity, null);
                    else
                        entity.GetType().GetProperty(fieldName).SetValue(entity, (int)jFieldValue);
                }
                else
                {
                    entity.GetType().GetProperty(fieldName).SetValue(entity, Convert.ChangeType(jFieldValue, fieldType));
                }
            }

            foreach (var fileData in filesData)
            {
                string path = appEnvironment.ContentRootPath + $"/AppData/Files/{entityType}/{entity.Id}/{fileData.Name}/";
                var directory = Directory.CreateDirectory(path);

                using (var fileStream = new FileStream(path + fileData.FileName, FileMode.Create))
                {
                    fileData.CopyTo(fileStream);
                }

                entity.GetType().GetProperty(fileData.Name).SetValue(entity, path + fileData.FileName);
            }

            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();

            return ResultHelper.Successed();
        }

        [HttpPost]
        [Route("/EntityObjects/{entityType}/Delete/{id}")]
        public ActionResult Delete(string entityType, int id)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entity = (EntityObject)dataContext.Set(type).Find(id);

            if (entity == null)
                return ResultHelper.EntityNotFound($"{id}");

            dataContext.Entry(entity).State = EntityState.Deleted;
            dataContext.SaveChanges();

            return ResultHelper.Successed();
        }

        [HttpGet]
        [Route("/EntityObjects/{entityType}/Download")]
        public ActionResult Download(string entityType, int id, string attributeName)
        {
            var type = Type.GetType($"TaskChecker.Models.{entityType}");

            if (type == null)
                return ResultHelper.EntityNotFound(entityType);

            var entity = (EntityObject)dataContext.Set(type).Find(id);

            if (entity == null)
                return ResultHelper.EntityNotFound($"{id}");

            if (attributeName == null || entity.GetType().GetProperty(attributeName) == null)
                return ResultHelper.Failed("Атрибут не найден");

            //Путь к файлу
            var attributeValue = (string)entity.GetType().GetProperty(attributeName).GetValue(entity, null);

            var fileInfo = new FileInfo(attributeValue);

            if (!fileInfo.Exists)
                return ResultHelper.Failed("Файл не найден");

            FileStream fileStream = new FileStream(attributeValue, FileMode.Open);
            new FileExtensionContentTypeProvider()
                .TryGetContentType(attributeValue, out string contentType);

            return File(fileStream, contentType, fileInfo.Name);
        }
    }
}

using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace TaskChecker.Models
{
    public partial class NotificationType
    {
        public static NotificationType Find(DataContext dataContext, string name)
        {
            return dataContext.Set<NotificationType>()
                .FirstOrDefault(x => x.Name == name);
        }

        public static NotificationType Obtain(DataContext dataContext, string name, string title)
        {
            var type = Find(dataContext, name);

            if (type == null)
            {
                type = new NotificationType()
                {
                    Name = name,
                    Title = title
                };

                dataContext.NotificationTypes.Add(type);
                dataContext.SaveChanges();
            }

            return type;
        }

        public static NotificationType NewMessage(DataContext dataContext)
        {
            var type = Find(dataContext, "NewMessage");

            if (type == null)
                type = Obtain(dataContext, "NewMessage", "Новое сообщение");

            return type;
        }

        public static NotificationType NewTaskToCheck(DataContext dataContext)
        {
            var type = Find(dataContext, "NewTaskToCheck");

            if (type == null)
                type = Obtain(dataContext, "NewTaskToCheck", "Новая задача на проверку");

            return type;
        }

        public static NotificationType TaskChecked(DataContext dataContext)
        {
            var type = Find(dataContext, "TaskChecked");

            if (type == null)
                type = Obtain(dataContext, "TaskChecked", "Задача проверена");

            return type;
        }

        public static void Install(DataContext dataContext)
        {
            NewMessage(dataContext);
            NewTaskToCheck(dataContext);
            TaskChecked(dataContext);
        }
    }
}

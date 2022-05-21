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
    public partial class NotificationChannel
    {
        public static NotificationChannel Find(DataContext dataContext, string name)
        {
            return dataContext.Set<NotificationChannel>()
                .FirstOrDefault(x => x.Name == name);
        }

        public static NotificationChannel Obtain(DataContext dataContext, string name, string title)
        {
            var channel = Find(dataContext, name);

            if (channel == null)
            {
                if (name == "LK")
                {
                    channel = new NotificationChannelLK()
                    {
                        Name = name,
                        Title = title
                    };

                    dataContext.NotificationChannelsLK.Add(channel as NotificationChannelLK);
                }

                dataContext.SaveChanges();
            }

            return channel;
        }

        public static NotificationChannel LK(DataContext dataContext)
        {
            var type = Find(dataContext, "LK");

            if (type == null)
                type = Obtain(dataContext, "LK", "Личный кабинет");

            return type;
        }

        public static void Install(DataContext dataContext)
        {
            LK(dataContext);
        }
    }
}

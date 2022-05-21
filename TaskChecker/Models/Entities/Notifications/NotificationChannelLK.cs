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
    [Table("NotificationChannel")]
    [ListDisplay("Каналы отправки уведомлений")]
    [EditDisplay("Канал отправки уведомления")]
    public partial class NotificationChannelLK : NotificationChannel
    {
        private DataContext dataContext;
        public NotificationChannelLK() : base() { }

        public NotificationChannelLK(DataContext context)
        {
            dataContext = context;
        }

        public override bool Send(DataContext dataContext, Notification notification)
        {
            notification.Read = false;
            notification = Notification.Create(dataContext, notification);

            return true;
        }
    }
}

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
    public abstract partial class NotificationChannel : EntityObject
    {
        private DataContext dataContext;
        public NotificationChannel() : base() { }

        public NotificationChannel(DataContext context)
        {
            dataContext = context;
        }

        /// <summary>
        /// Название
        /// </summary>
        [ListDisplay("Название")]
        [DetailDisplay("Название")]
        [EditDisplay("Название")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        [Column("Title")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(3)]
        public string Title { get; set; }

        /// <summary>
        /// Системное название
        /// </summary>
        [ListDisplay("Системное название")]
        [DetailDisplay("Системное название")]
        [EditDisplay("Системное название")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Системное название' обязательно для заполнения")]
        [Column("Name")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(2)]
        public string Name { get; set; }

        public abstract bool Send(DataContext dataContext, Notification notification);
    }
}

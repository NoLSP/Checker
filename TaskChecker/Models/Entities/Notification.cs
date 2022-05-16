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
    [Table("Notification")]
    [ListDisplay("Уведомления")]
    [EditDisplay("Уведомление")]
    public partial class Notification : EntityObject
    {
        private DataContext dataContext;
        public Notification() : base() { }

        public Notification(DataContext context)
        {
            dataContext = context;
        }

        /// <summary>
        /// Заголовок
        /// </summary>
        [ListDisplay("Заголовок")]
        [DetailDisplay("Заголовок")]
        [EditDisplay("Заголовок")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Заголовок' обязательно для заполнения")]
        [Column("Title")]
        [StringLength(512, ErrorMessage = "Строка слишком длинная")]
        public string Title { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        [ListDisplay("Текст")]
        [DetailDisplay("Текст")]
        [EditDisplay("Текст")]
        [InputType("text")]
        [FieldType(FieldTypes.String)]
        [Column("Text")]
        public string Text { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        [ListDisplay("Ссылка")]
        [DetailDisplay("Ссылка")]
        [EditDisplay("Ссылка")]
        [InputType("text")]
        [FieldType(FieldTypes.String)]
        [Column("Link")]
        [StringLength(2048, ErrorMessage = "Строка слишком длинная")]
        public string Link { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [ListDisplay("Получатель")]
        [DetailDisplay("Получатель")]
        [EditDisplay("Получатель")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Получатель' обязательно для заполнения")]
        [ForeignKey("Reaciever_id")]
        public User Reaciever
        {
            get
            {
                if (_reaciever == null)
                    _reaciever = dataContext.Set<User>().First(x => x.Id == this.Reaciever_id);
                return _reaciever;
            }
            set => _reaciever = value;
        }
        private User _reaciever;
        [Column("Reaciever_id")]
        public int Reaciever_id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [ListDisplay("Тип")]
        [DetailDisplay("Тип")]
        [EditDisplay("Тип")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Тип' обязательно для заполнения")]
        [ForeignKey("Type_id")]
        public NotificationType Type
        {
            get
            {
                if (_type == null)
                    _type = dataContext.Set<NotificationType>().First(x => x.Id == this.Type_id);
                return _type;
            }
            set => _type = value;
        }
        private NotificationType _type;
        [Column("Type_id")]
        public int Type_id { get; set; }

        /// <summary>
        /// Прочитано
        /// </summary>
        [ListDisplay("Прочитано")]
        [DetailDisplay("Прочитано")]
        [EditDisplay("Прочитано")]
        [InputType("checkbox")]
        [NotNull]
        [FieldType(FieldTypes.Boolean)]
        [Required(ErrorMessage = "Поле 'Прочитано' обязательно для заполнения")]
        [Column("Read")]
        public bool Read { get; set; }
    }
}

using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskChecker.Models
{
    [Table("StudentsGroupCourse")]
    public partial class StudentsGroupCourse : EntityObject
    {
        private DataContext dataContext;

        public StudentsGroupCourse(DataContext context)
        {
            dataContext = context;
        }

        public StudentsGroupCourse() : base()
        {

        }

        /// <summary>
        /// Студенческая группа
        /// </summary>
        [ListDisplay("Студенческая группа")]
        [DetailDisplay("Студенческая группа")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Студенческая группа' обязательно для заполнения")]
        [ForeignKey("StudentsGroup_id")]
        public virtual StudentsGroup StudentsGroup { get; set; }
        [Column("StudentsGroup_id")]
        [Order(2)]
        public int StudentsGroup_id { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        [ListDisplay("Курс")]
        [DetailDisplay("Курс")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Курс' обязательно для заполнения")]
        [ForeignKey("Course_id")]
        public virtual Course Course { get; set; }
        [Column("Course_id")]
        [Order(3)]
        public int Course_id { get; set; }
    }
}

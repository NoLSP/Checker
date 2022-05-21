using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskChecker.Models
{
    [Table("StudentTaskTeacherResult")]
    [ListDisplay("Результаты")]
    [EditDisplay("Результат")]
    public partial class StudentTaskTeacherResult : EntityObject
    {
        private DataContext dataContext;

        public StudentTaskTeacherResult(DataContext context)
        {
            dataContext = context;
        }

        public StudentTaskTeacherResult() : base()
        {

        }
        
        /// <summary>
        /// Студент
        /// </summary>
        [ListDisplay("Студент")]
        [EditDisplay("Студент")]
        [DetailDisplay("Студент")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Студент' обязательно для заполнения")]
        [ForeignKey("Student_id")]
        [Order(2)]
        public User Student { get; set; }
        [Column("Student_id")]
        public int Student_id { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        [EditDisplay("Задача")]
        [DetailDisplay("Задача")]
        [ListDisplay("Задача")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Задача' обязательно для заполнения")]
        [ForeignKey("Task_id")]
        [Order(3)]
        public Task Task { get; set; }
        [Column("Task_id")]
        public int Task_id { get; set; }

        /// <summary>
        /// Оценка учителя
        /// </summary>
        [EditDisplay("Оценка учителя")]
        [DetailDisplay("Оценка учителя")]
        [ListDisplay("Оценка учителя")]
        [InputType("number")]
        [FieldType(FieldTypes.Int)]
        [Column("TeacherResult")]
        [Order(4)]
        public int? TeacherResult { get; set; }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        [DetailDisplay("Дата и время создания")]
        [NotNull]
        [FieldType(FieldTypes.DateTime)]
        [Column("CreationDateTime")]
        [Order(5)]
        public DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Дата и время состояния
        /// </summary>
        [DetailDisplay("Дата и время состояния")]
        [NotNull]
        [FieldType(FieldTypes.DateTime)]
        [Column("StateDateTime")]
        [Order(6)]
        public DateTime StateDateTime { get; set; }

        /// <summary>
        /// Дата и время загрузки решения
        /// </summary>
        [DetailDisplay("Дата и время загрузки решения")]
        [ListDisplay("Дата и время загрузки решения")]
        [FieldType(FieldTypes.DateTime)]
        [Column("SolutionLoadDateTime")]
        [Order(7)]
        public DateTime? SolutionLoadDateTime { get; set; }

        /// <summary>
        /// Файл студента
        /// </summary>
        [DetailDisplay("Файл студента")]
        [ListDisplay("Файл студента")]
        [EditDisplay("Файл студента")]
        [FieldType(FieldTypes.File)]
        [InputType("file")]
        [Column("StudentFilePath")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(9)]
        public string StudentFilePath { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [DetailDisplay("Статус")]
        [EditDisplay("Статус")]
        [ListDisplay("Статус")]
        [InputType("select")]
        [NotNull] 
        [FieldType(FieldTypes.Link)]
        [ForeignKey("TaskState_id")]
        [Order(8)]
        public TaskState TaskState { get; set; }
        [Column("TaskState_id")]
        public int? TaskState_id { get; set; }
    }
}

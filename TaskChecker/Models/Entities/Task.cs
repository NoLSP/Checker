using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace TaskChecker.Models
{
    [Table("Task")]
    [ListDisplay("Задачи")]
    [EditDisplay("Задача")]
    public partial class Task : EntityObject
    {
        private DataContext dataContext;

        public Task(DataContext context)
        {
            dataContext = context;
        }

        public Task() : base()
        {

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
        [Order(2)]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [ListDisplay("Описание")]
        [DetailDisplay("Описание")]
        [EditDisplay("Описание")]
        [InputType("textarea")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Описание' обязательно для заполнения")]
        [Column("Description")]
        [Order(3)]
        public string Description { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        [ListDisplay("Курс")]
        [DetailDisplay("Курс")]
        [EditDisplay("Курс")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Группа задач' обязательно для заполнения")]
        [ForeignKey("Course_id")]
        [Order(4)]
        public virtual Course Course { get; set; }
        [Column("Course_id")]
        public int Course_id { get; set; }

        /// <summary>
        /// Язык программирования
        /// </summary>
        [ListDisplay("Язык программирования")]
        [DetailDisplay("Язык программирования")]
        [EditDisplay("Язык программирования")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Язык программирования' обязательно для заполнения")]
        [ForeignKey("ProgrammingLanguage_id")]
        [Order(5)]
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
        [Column("ProgrammingLanguage_id")]
        public int ProgrammingLanguage_id { get; set; }

        /// <summary>
        /// Максимально возможный результат
        /// </summary>
        [ListDisplay("Макс. результат")]
        [DetailDisplay("Макс. результат")]
        [EditDisplay("Макс. результат")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.Int)]
        [Required(ErrorMessage = "Поле 'Максю результат' обязательно для заполнения")]
        [Column("MaxResult")]
        [Order(6)]
        public int MaxResult { get; set; }

        /// <summary>
        /// Дата окончания приема
        /// </summary>
        [DetailDisplay("Дата окончания приема")]
        [ListDisplay("Дата окончания приема")]
        [EditDisplay("Дата окончания приема")]
        [FieldType(FieldTypes.DateTime)]
        [InputType("datetime-local")]
        [Column("Deadline")]
        [Order(7)]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// Процент выполненных тестов
        /// </summary>
        [ListDisplay("Процент выполненных тестов")]
        [DetailDisplay("Процент выполненных тестов")]
        [EditDisplay("Процент выполненных тестов")]
        [InputType("number")]
        [NotNull]
        [FieldType(FieldTypes.Int)]
        [Required(ErrorMessage = "Поле 'Процент выполненных тестов' обязательно для заполнения")]
        [Column("MinimumTestsPercent")]
        [Order(8)]
        public int MinimumTestsPercent { get; set; }

        /// <summary>
        /// Тесты
        /// </summary>
        [ListDisplay("Тесты")]
        [DetailDisplay("Тесты")]
        [NotNull]
        [FieldType(FieldTypes.List)]
        [Order(9)]
        public virtual IList<Test> Tests
        {
            get
            {
                if (_tests == null)
                    _tests = dataContext.Set<Test>().Where(x => x.Task_id == this.Id).ToList();
                return _tests;
            }
            set => _tests = value;
        }
        private IList<Test> _tests;
    }
}

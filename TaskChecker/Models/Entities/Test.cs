using TaskChecker.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskChecker.Models
{
    [Table("Test")]
    [ListDisplay("Тесты")]
    [EditDisplay("Тест")]
    public partial class Test : EntityObject
    {
        private DataContext dataContext;

        public Test(DataContext context)
        {
            dataContext = context;
        }

        public Test() : base()
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
        [InputType("text")]
        [FieldType(FieldTypes.String)]
        [Column("Description")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(3)]
        public string Description { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        [ListDisplay("Задача")]
        [DetailDisplay("Задача")]
        [EditDisplay("Задача")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Задача' обязательно для заполнения")]
        [ForeignKey("Task_id")]
        [Order(4)]
        public virtual Task Task { get; set; }
        [Column("Task_id")]
        public int Task_id { get; set; }

        /// <summary>
        /// Входное значение
        /// </summary>
        [ListDisplay("Входное значение")]
        [DetailDisplay("Входное значение")]
        [EditDisplay("Входное значение")]
        [InputType("text")]
        [FieldType(FieldTypes.String)]
        [Column("InputValue")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(5)]
        public string InputValue { get; set; }

        /// <summary>
        /// Ожидаемый результат
        /// </summary>
        [ListDisplay("Ожидаемый результат")]
        [DetailDisplay("Ожидаемый результат")]
        [EditDisplay("Ожидаемый результат")]
        [InputType("text")]
        [FieldType(FieldTypes.String)]
        [Column("ExpectedResult")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(6)]
        public string ExpectedResult { get; set; }

        /// <summary>
        /// Путь к тестовому файлу
        /// </summary>
        [ListDisplay("Тестовый файл")]
        [DetailDisplay("Тестовый файл")]
        [EditDisplay("Тестовый файл")]
        [FieldType(FieldTypes.File)]
        [InputType("file")]
        [Column("TestFilePath")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(7)]
        public string TestFilePath { get; set; }
    }
}

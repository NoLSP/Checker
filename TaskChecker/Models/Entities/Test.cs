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
        public string Title { get; set; }

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
        public virtual Task Task { get; set; }
        [Column("Task_id")]
        public int Task_id { get; set; }

        /// <summary>
        /// Путь к тестовому файлу
        /// </summary>
        [ListDisplay("Тестовый файл")]
        [DetailDisplay("Тестовый файл")]
        [EditDisplay("Тестовый файл")]
        [NotNull]
        [FieldType(FieldTypes.File)]
        [InputType("file")]
        [Required(ErrorMessage = "Поле 'Тестовый файл' обязательно для заполнения")]
        [Column("TestFilePath")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string TestFilePath { get; set; }
    }
}

using TaskChecker.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskChecker.Models
{
    [Table("StudentTestResult")]
    [ListDisplay("Результаты тестов")]
    [EditDisplay("Результат теста")]
    public partial class StudentTestResult : EntityObject
    {
        private DataContext dataContext;

        public StudentTestResult(DataContext context)
        {
            dataContext = context;
        }

        public StudentTestResult() : base()
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
        public User Student { get; set; }
        [Column("Student_id")]
        public int Student_id { get; set; }

        /// <summary>
        /// Тест
        /// </summary>
        [ListDisplay("Тест")]
        [EditDisplay("Тест")]
        [DetailDisplay("Тест")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Тест' обязательно для заполнения")]
        [ForeignKey("Test_id")]
        public Test Test { get; set; }
        [Column("Test_id")]
        public int Test_id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [ListDisplay("Статус")]
        [EditDisplay("Статус")]
        [DetailDisplay("Статус")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Статус' обязательно для заполнения")]
        [ForeignKey("TestState_id")]
        public TestState TestState { get; set; }
        [Column("TestState_id")]
        public int TestState_id { get; set; }
    }
}

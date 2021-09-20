using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("TasksTests")]
    public partial class TasksTests
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        [Display(Name = "Задача")]
        [Required(ErrorMessage = "Поле 'Задача' обязательно для заполнения")]
        [ForeignKey("Task_id")]
        public virtual Task Task { get; set; }
        [Column("Task_id")]
        public int Task_id { get; set; }

        /// <summary>
        /// Тест
        /// </summary>
        [Display(Name = "Тест")]
        [Required(ErrorMessage = "Поле 'Тест' обязательно для заполнения")]
        [ForeignKey("Test_id")]
        public virtual Test Test { get; set; }
        [Column("Test_id")]
        public int Test_id { get; set; }
    }
}

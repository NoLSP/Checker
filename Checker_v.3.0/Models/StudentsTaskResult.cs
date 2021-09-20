using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("StudentsTaskResult")]
    public partial class StudentsTaskResult : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public StudentsTaskResult(DataContext context, ILazyLoader loader)
        {
            dataContext = context;
            lazyLoader = loader;
        }

        public StudentsTaskResult() : base()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Студент
        /// </summary>
        [Display(Name = "Студент")]
        [Required(ErrorMessage = "Поле 'Студент' обязательно для заполнения")]
        [ForeignKey("Student_id")]
        public User Student { get; set; }
        [Column("Student_id")]
        public int Student_id { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        [Display(Name = "Задача")]
        [Required(ErrorMessage = "Поле 'Задача' обязательно для заполнения")]
        [ForeignKey("Task_id")]
        public Task Task { get; set; }
        [Column("Task_id")]
        public int Task_id { get; set; }

        /// <summary>
        /// Оценка учителя
        /// </summary>
        [Display(Name = "Оценка учителя")]
        [Column("TeacherResult")]
        public int? TeacherResult { get; set; }
    }
}

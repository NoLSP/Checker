using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("Task")]
    public partial class Task : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public Task(DataContext context, ILazyLoader loader)
        {
            dataContext = context;
            lazyLoader = loader;
        }

        public Task() : base()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        [Column("Title")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле 'Описание' обязательно для заполнения")]
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Группа задач
        /// </summary>
        [Display(Name = "Группа задач")]
        [Required(ErrorMessage = "Поле 'Группа задач' обязательно для заполнения")]
        [ForeignKey("Group_id")]
        public virtual TasksGroup Group { get; set; }
        [Column("Group_id")]
        public int Group_id { get; set; }

        /// <summary>
        /// Максимально возможный результат
        /// </summary>
        [Display(Name = "Макс. результат")]
        [Required(ErrorMessage = "Поле 'Максю результат' обязательно для заполнения")]
        [Column("MaxResult")]
        public int MaxResult { get; set; }

        private ICollection<Test> _tests;
        public virtual ICollection<Test> Tests
        {
            get => _tests ?? lazyLoader.Load(this, ref _tests);
            set => _tests = value;
        }
    }
}

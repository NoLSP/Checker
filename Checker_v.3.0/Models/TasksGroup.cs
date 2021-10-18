using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checker_v._3._0.Models
{
    [Table("TasksGroup")]
    public class TasksGroup : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public TasksGroup(DataContext context, ILazyLoader loader)
        {
            dataContext = context;
            lazyLoader = loader;
        }

        public TasksGroup() : base()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Системное название
        /// </summary>
        [Display(Name = "Системное название")]
        [Required(ErrorMessage = "Поле 'Системное название' обязательно для заполнения")]
        [Column("Name")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string Name { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        [Column("Title")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string Title { get; set; }

        private ICollection<Task> _tasks;
        public virtual ICollection<Task> Tasks
        {
            get => _tasks ?? lazyLoader.Load(this, ref _tasks);
            set => _tasks = value;
        }
    }
}

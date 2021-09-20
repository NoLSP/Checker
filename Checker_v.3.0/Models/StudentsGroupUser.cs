using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("StudentsInGroup")]
    public partial class StudentsGroupUser : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public StudentsGroupUser(DataContext context, ILazyLoader loader)
        {
            dataContext = context;
            lazyLoader = loader;
        }

        public StudentsGroupUser() : base()
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
        public virtual User Student { get; set; }
        [Column("Student_id")]
        public int Student_id { get; set; }

        /// <summary>
        /// Студенческая группа
        /// </summary>
        [Display(Name = "Студенческая группа")]
        [Required(ErrorMessage = "Поле 'Студенческая группа' обязательно для заполнения")]
        [ForeignKey("Group_id")]
        public virtual StudentsGroup Group { get; set; }
        [Column("Group_id")]
        public int Group_id { get; set; }
    }
}

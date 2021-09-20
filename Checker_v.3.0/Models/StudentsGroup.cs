using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("StudentsGroup")]
    public partial class StudentsGroup : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public StudentsGroup() : base()
        {

        }

        public StudentsGroup(DataContext context, ILazyLoader loader)
        {
            dataContext = context;
            lazyLoader = loader;
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
        /// Владелец
        /// </summary>
        [Display(Name = "Владелец")]
        [Required(ErrorMessage = "Поле 'Владелец' обязательно для заполнения")]
        [ForeignKey("Owner_id")]
        public User Owner 
        {
            get => _owner ?? lazyLoader.Load(this, ref _owner);
            set => _owner = value;
        }
        private User _owner;
        [Column("Owner_id")]
        public int Owner_id { get; set; }
        public List<StudentsGroupUser> StudentsGroupUsers { get; set; } = new List<StudentsGroupUser>();
        public List<User> Users { get; set; } = new List<User>();
    }
}

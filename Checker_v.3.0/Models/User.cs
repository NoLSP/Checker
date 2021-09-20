using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("User")]
    public partial class User : EntityObject
    {
        private DataContext dataContext;
        private ILazyLoader lazyLoader;

        public User() : base()
        {

        }
        

        public User(DataContext context, ILazyLoader loader)
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
        /// Ф.И.О.
        /// </summary>
        [Display(Name = "Ф.И.О.")]
        [Required(ErrorMessage = "Поле 'Ф.И.О.' обязательно для заполнения")]
        [Column("FullName")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string FullName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле 'Короткое имя' обязательно для заполнения")]
        [Column("ShortName")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string ShortName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле 'Email' обязательно для заполнения")]
        [Column("Email")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле 'пароль' обязательно для заполнения")]
        [Column("Password")]
        public string Password { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Поле 'Роль' обязательно для заполнения")]
        [ForeignKey("Role_id")]
        public UserRole Role
        {
            get => _role ?? lazyLoader.Load(this, ref _role);
            set => _role = value;
        }
        private UserRole _role;
        [Column("Role_id")]
        public int Role_id { get; set; }
        public List<StudentsGroup> StudenstGroups { get; set; } = new List<StudentsGroup>();
        public List<StudentsGroupUser> StudentsGroupUsers { get; set; } = new List<StudentsGroupUser>();
    }
}

using Microsoft.EntityFrameworkCore;
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
        public User() : base() { }

        public User(DataContext context)
        {
            dataContext = context;
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
            get
            {
                if (_role == null)
                    _role = dataContext.Set<UserRole>().First(x => x.Id == this.Role_id);
                return _role;
            }
            set => _role = value;
        }
        private UserRole _role;
        [Column("Role_id")]
        public int Role_id { get; set; }

        /// <summary>
        /// Группы
        /// </summary>
        [Display(Name = "Группы")]
        [NotMapped]
        public List<StudentsGroup> StudentGroups
        {
            get
            {
                if (_StudentsGroups == null && StudentsGroupUsers != null)
                    _StudentsGroups = StudentsGroupUsers.Select(x => x.Group).ToList();
                else if (dataContext != null)
                    _StudentsGroups = dataContext.Set<StudentsGroupUser>().Include(x => x.Group).Where(x => x.Student_id == this.Id).Select(x => x.Group).ToList();
                return _StudentsGroups;
            }
            set => _StudentsGroups = value;
        }
        private List<StudentsGroup> _StudentsGroups;

        public IList<StudentsGroupUser> StudentsGroupUsers
        {
            get
            {
                if (_StudentsGroupUsers == null)
                    _StudentsGroupUsers = dataContext.Set<StudentsGroupUser>().Include(x => x.Group).Where(x => x.Student_id == this.Id).ToList();
                return _StudentsGroupUsers;
            }
            set => _StudentsGroupUsers = value;
        }
        private IList<StudentsGroupUser> _StudentsGroupUsers;
    }
}

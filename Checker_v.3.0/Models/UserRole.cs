using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("UserRole")]
    public partial class UserRole : EntityObject
    {
        private DataContext dataContext;

        public UserRole(DataContext context)
        {
            dataContext = context;
        }

        public UserRole() : base()
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

        private ICollection<User> _users;
        public virtual ICollection<User> Users
        {
            get
            {
                if (_users == null)
                    _users = dataContext.Set<User>().Where(x => x.Role_id == this.Id).ToList();
                return _users;
            }
            set => _users = value;
        }
    }
}

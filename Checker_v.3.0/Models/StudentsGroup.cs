using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        /// <summary>
        /// Студенты
        /// </summary>
        [Display(Name = "Студенты")]
        [NotMapped]
        public IList<User> Users
        {
            get
            {
                if (_Users == null && StudentsGroupUsers != null)
                    _Users = StudentsGroupUsers.Select(x => x.Student).ToList();
                else if (_Users == null && dataContext != null)
                    _Users = dataContext.Set<StudentsGroupUser>().Where(x => x.Group.Id == this.Id).Select(x => x.Student).ToList();
                return _Users;
            }
            set => _Users = value;
        }
        private IList<User> _Users;

        public List<StudentsGroupUser> StudentsGroupUsers { get; set; }
    }
}

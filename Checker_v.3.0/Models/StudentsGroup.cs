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

        public StudentsGroup() : base()
        {

        }

        public StudentsGroup(DataContext context)
        {
            dataContext = context;
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
            get
            {
                if (_owner == null)
                    _owner = dataContext.Set<User>()
                        .Where(x => dataContext.Set<StudentsGroupUser>()
                                        .Where(y => y.Group_id == this.Id)
                                        .FirstOrDefault().Student_id == x.Id)
                        .FirstOrDefault();
                return _owner;
            }
            set => _owner = value;
        }
        private User _owner;
        [Column("Owner_id")]
        public int Owner_id { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        [Display(Name = "Курс")]
        [Required(ErrorMessage = "Поле 'курс' обязательно для заполнения")]
        [ForeignKey("TasksGroup_id")]
        public TasksGroup TaskGroup
        {
            get
            {
                if (_taskGroup == null)
                    _taskGroup = dataContext.Set<TasksGroup>().Where(x => x.Id == this.TasksGroup_id).FirstOrDefault();
                return _taskGroup;
            }
            set => _taskGroup = value;
        }
        private TasksGroup _taskGroup;
        [Column("TasksGroup_id")]
        public int TasksGroup_id { get; set; }

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

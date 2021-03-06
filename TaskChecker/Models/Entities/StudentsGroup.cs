using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace TaskChecker.Models
{
    [Table("StudentsGroup")]
    [ListDisplay("Студенческие группы")]
    [EditDisplay("Студенческая грппа")]
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

        /// <summary>
        /// Название
        /// </summary>
        [ListDisplay("Название")]
        [DetailDisplay("Название")]
        [EditDisplay("Название")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Название' обязательно для заполнения")]
        [Column("Title")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(2)]
        public string Title { get; set; }

        /// <summary>
        /// Владелец
        /// </summary>
        [ListDisplay("Владелец")]
        [DetailDisplay("Владелец")]
        [EditDisplay("Владелец")]
        [InputType("select")]
        [NotNull]
        [FieldType(FieldTypes.Link)]
        [Required(ErrorMessage = "Поле 'Владелец' обязательно для заполнения")]
        [ForeignKey("Owner_id")]
        [Order(3)]
        public User Owner
        {
            get
            {
                if (_owner == null)
                    _owner = dataContext.Set<User>()
                        .Where(x => x.Role.Name == "Teacher")
                        .Where(x => x.Id == this.Owner_id)
                        .FirstOrDefault();
                return _owner;
            }
            set => _owner = value;
        }
        private User _owner;
        [Column("Owner_id")]
        public int Owner_id { get; set; }

        /// <summary>
        /// Курсы
        /// </summary>
        [ListDisplay("Курсы")]
        [DetailDisplay("Курсы")]
        [NotNull]
        [FieldType(FieldTypes.List)]
        [NotMapped]
        [Order(4)]
        public IList<Course> Courses
        {
            get
            {
                if (_courses == null)
                {
                    if (StudentsGroupsCourses == null)
                    {
                        StudentsGroupsCourses = dataContext.StudentsGroupCourses
                            .Where(x => x.StudentsGroup_id == this.Id)
                            .ToList();
                    }
                    _courses = StudentsGroupsCourses.Select(x => x.Course).ToList();
                }
                else if (_courses == null && dataContext != null)
                    _courses = dataContext.Set<StudentsGroupCourse>().Where(x => x.StudentsGroup_id == this.Id).Select(x => x.Course).ToList();
                return _courses;
            }
            set => _courses = value;
        }
        private IList<Course> _courses;

        public List<StudentsGroupCourse> StudentsGroupsCourses { get; set; }

        /// <summary>
        /// Студенты
        /// </summary>
        [ListDisplay("Студенты")]
        [DetailDisplay("Студенты")]
        [NotNull]
        [FieldType(FieldTypes.List)]
        [NotMapped]
        [Order(5)]
        public IList<User> Students
        {
            get
            {
                if (_students == null)
                    _students = dataContext.Set<User>().Where(x => x.StudentsGroup_id == this.Id).ToList();
                return _students;
            }
            set => _students = value;
        }
        private IList<User> _students;
    }
}

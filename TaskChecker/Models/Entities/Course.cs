using TaskChecker.Models.Attributes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    [Table("Course")]
    [ListDisplay("Курсы")]
    [EditDisplay("Курс")]
    public class Course : EntityObject
    {
        private DataContext dataContext;

        public Course(DataContext context)
        {
            dataContext = context;
        }

        public Course() : base()
        {

        }

        /// <summary>
        /// Системное название
        /// </summary>
        [ListDisplay("Системное название")]
        [DetailDisplay("Системное название")]
        [EditDisplay("Системное название")]
        [InputType("text")]
        [NotNull]
        [FieldType(FieldTypes.String)]
        [Required(ErrorMessage = "Поле 'Системное название' обязательно для заполнения")]
        [Column("Name")]
        [StringLength(255, ErrorMessage = "Строка слишком длинная")]
        [Order(2)]
        public string Name { get; set; }

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
        [Order(3)]
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
        [Order(4)]
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
        /// Задачи
        /// </summary>
        [ListDisplay("Задачи")]
        [DetailDisplay("Задачи")]
        [FieldType(FieldTypes.List)]
        [NotMapped]
        [Order(5)]
        public IList<Task> Tasks
        {
            get
            {
                if (_tasks == null)
                    _tasks = dataContext.Set<Task>().Where(x => x.Course_id == this.Id).ToList();
                return _tasks;
            }
            set => _tasks = value;
        }
        private IList<Task> _tasks;

        /// <summary>
        /// Студенческие группы
        /// </summary>
        [ListDisplay("Студ. группы")]
        [DetailDisplay("Студ. группы")]
        [FieldType(FieldTypes.List)]
        [NotMapped]
        [Order(6)]
        public IList<StudentsGroup> StudentsGroups
        {
            get
            {
                if (_studentsGroups == null)
                {
                    if (StudentsGroupsCourses == null)
                    {
                        StudentsGroupsCourses = dataContext.StudentsGroupCourses
                            .Where(x => x.Course_id == this.Id)
                            .ToList();
                    }
                    _studentsGroups = StudentsGroupsCourses.Select(x => x.StudentsGroup).ToList();
                }
                else if (_studentsGroups == null && dataContext != null)
                    _studentsGroups = dataContext.Set<StudentsGroupCourse>().Where(x => x.Course_id == this.Id).Select(x => x.StudentsGroup).ToList();
                return _studentsGroups;
            }
            set => _studentsGroups = value;
        }
        private IList<StudentsGroup> _studentsGroups;

        public List<StudentsGroupCourse> StudentsGroupsCourses { get; set; }
    }
}

using TaskChecker.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskChecker.Models
{
    [ListDisplay("Состояния тестов")]
    [EditDisplay("Состояние теста")]
    [Table("TestState")]
    public partial class TestState : EntityObject
    {
        private DataContext dataContext;

        public TestState(DataContext context)
        {
            dataContext = context;
        }

        public TestState() : base()
        {

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
        [Order(3)]
        public string Title { get; set; }

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
    }
}

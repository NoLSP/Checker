using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Checker_v._3._0.Models
{
    [Table("StudentTestResult")]
    public partial class StudentTestResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Поле 'Id' обязательно для заполнения")]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'StudentId' обязательно для заполнения")]
        [Column("Student_id")]
        public int Student_id { get; set; }
        public virtual User Student { get; set; }

        [Required(ErrorMessage = "Поле 'TestId' обязательно для заполнения")]
        [Column("Test_id")]
        public int Test_id { get; set; }
        public virtual Test Test { get; set; }

        [Required(ErrorMessage = "Поле 'StateId' обязательно для заполнения")]
        [Column("State_id")]
        public int StateId { get; set; }
        public virtual TestState State { get; set; }
    }
}

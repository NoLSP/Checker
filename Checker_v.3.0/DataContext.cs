using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Checker_v._3._0.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentsGroup> StudentsGroups { get; set; }
        public virtual DbSet<StudentTaskResult> StudentsTaskResults { get; set; }
        public virtual DbSet<StudentsGroupCourse> StudentsGroupCourse { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskState> TaskStates { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestState> TestStates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<StudentTestResult> StudentsTestsResults { get; set; }
        public virtual DbSet<Course> TaskGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasPostgresExtension("pgagent")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<StudentsGroup>()
                .HasOne(p => p.Owner);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(p => p.Role_id);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Group)
                .WithMany(t => t.Students)
                .HasForeignKey(p => p.StudentsGroup_id);

            modelBuilder.Entity<Test>()
                .HasOne(p => p.Task)
                .WithMany(t => t.Tests)
                .HasForeignKey(p => p.Task_id);

            modelBuilder.Entity<Task>()
                .HasOne(p => p.Course)
                .WithMany(t => t.Tasks)
                .HasForeignKey(p => p.Course_id);

            modelBuilder.Entity<StudentsGroupCourse>()
                 .HasOne(p => p.StudentsGroup)
                 .WithMany(t => t.StudentsGroupsCourses)
                 .HasForeignKey(p => p.StudentsGroup_id);

            modelBuilder.Entity<StudentsGroupCourse>()
                 .HasOne(p => p.Course)
                 .WithMany(t => t.StudentsGroupsCourses)
                 .HasForeignKey(p => p.Course_id);

            modelBuilder.Entity<StudentsGroupCourse>()
                .Navigation(x => x.StudentsGroup).AutoInclude();

            modelBuilder.Entity<StudentsGroupCourse>()
                .Navigation(x => x.Course).AutoInclude();

            modelBuilder.Entity<User>()
                .Navigation(x => x.Group).AutoInclude();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

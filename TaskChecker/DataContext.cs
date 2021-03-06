using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaskChecker.Models
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
        public virtual DbSet<StudentTaskTeacherResult> StudentsTaskTeacherResults { get; set; }
        public virtual DbSet<StudentsGroupCourse> StudentsGroupCourses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskState> TaskStates { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestState> TestStates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<StudentTestResult> StudentsTestsResults { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<NotificationChannel> NotificationChannels { get; set; }
        public virtual DbSet<NotificationChannelLK> NotificationChannelsLK { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasPostgresExtension("pgagent")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<StudentsGroup>()
                .HasOne(p => p.Owner);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.Reaciever);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.Type);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.Channel);

            modelBuilder.Entity<Course>()
                .HasOne(p => p.Owner);

            modelBuilder.Entity<StudentTaskTeacherResult>()
               .HasOne(p => p.Student);

            modelBuilder.Entity<StudentTaskTeacherResult>()
               .HasOne(p => p.Task);

            modelBuilder.Entity<StudentTaskTeacherResult>()
               .HasOne(p => p.TaskState);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Role);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Group)
                .WithMany(t => t.Students)
                .HasForeignKey(p => p.StudentsGroup_id);

            modelBuilder.Entity<Test>()
                .HasOne(p => p.Task)
                .WithMany(t => t.Tests)
                .HasForeignKey(p => p.Task_id);

            modelBuilder.Entity<ProgrammingLanguage>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.ProgrammingLanguage)
                .HasForeignKey(p => p.ProgrammingLanguage_id);

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

            modelBuilder.Entity<StudentTaskTeacherResult>()
                .Navigation(x => x.Student).AutoInclude();

            modelBuilder.Entity<StudentTaskTeacherResult>()
                .Navigation(x => x.Task).AutoInclude();

            modelBuilder.Entity<StudentTaskTeacherResult>()
                .Navigation(x => x.TaskState).AutoInclude();

            modelBuilder.Entity<Task>()
                .Navigation(x => x.Course).AutoInclude();

            modelBuilder.Entity<Task>()
                .Navigation(x => x.ProgrammingLanguage).AutoInclude();

            modelBuilder.Entity<Test>()
                .Navigation(x => x.Task).AutoInclude();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

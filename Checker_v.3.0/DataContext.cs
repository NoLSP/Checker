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
        public virtual DbSet<StudentsTaskResult> StudentsTaskResults { get; set; }
        public virtual DbSet<StudentsGroupUser> StuentsInGroups { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskState> TaskStates { get; set; }
        public virtual DbSet<TasksTests> TasksTests { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestState> TestStates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<StudentsTestsResult> StudentsTestsResults { get; set; }
        public virtual DbSet<TaskGroup> TaskGroups { get; set; }

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

            modelBuilder.Entity<Test>()
                .HasOne(p => p.Task)
                .WithMany(t => t.Tests)
                .HasForeignKey(p => p.Task_id);

            modelBuilder.Entity<Task>()
                .HasOne(p => p.Group)
                .WithMany(t => t.Tasks)
                .HasForeignKey(p => p.Group_id);

            modelBuilder.Entity<User>()
                .HasMany(c => c.StudenstGroups)
                .WithMany(s => s.Users)
                .UsingEntity(j => j.ToTable("StudentsGroupUser"));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

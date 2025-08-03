using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MVC02.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<crsResult> crsResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Course-Department relationship
            modelBuilder.Entity<Course>()
              .HasOne(c => c.Department)
              .WithMany(d => d.Courses)
              .HasForeignKey(c => c.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);

            // Configure Instructor-Course relationship
            modelBuilder.Entity<Instructor>()
              .HasOne(i => i.Course)
              .WithMany(c => c.Instructors)
              .HasForeignKey(i => i.CourseId)
              .OnDelete(DeleteBehavior.SetNull);

            // Configure Instructor-Department relationship
            modelBuilder.Entity<Instructor>()
              .HasOne(i => i.Department)
              .WithMany(d => d.Instructors)
              .HasForeignKey(i => i.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);

            // Configure Trainee-Department relationship
            modelBuilder.Entity<Trainee>()
              .HasOne(t => t.department)
              .WithMany(d => d.Trainees)
              .HasForeignKey(t => t.departmentId)
              .OnDelete(DeleteBehavior.Restrict);

            // Configure Course-Trainee many-to-many relationship through crsResult
            modelBuilder.Entity<crsResult>()
              .HasKey(cr => new { cr.CourseId, cr.TraineeId });

            modelBuilder.Entity<crsResult>()
              .HasOne(cr => cr.Course)
              .WithMany(c => c.crsResults)
              .HasForeignKey(cr => cr.CourseId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<crsResult>()
              .HasOne(cr => cr.Trainee)
              .WithMany(t => t.Crs)
              .HasForeignKey(cr => cr.TraineeId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
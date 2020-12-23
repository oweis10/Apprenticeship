using System;
using System.Collections.Generic;
using System.Text;
using Apprenticeship.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursesSkills> CoursesSkills { get; set; }
        public virtual DbSet<TaskFiles> TaskFiles { get; set; }
        public virtual DbSet<Taskss> Tasks { get; set; }
        public virtual DbSet<TasksComments> TasksComments { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<SchoolMentor> SchoolMentors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PlacementsNoses> PlacementsNoses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<WorkMentor> WorkMentors { get; set; }
        public virtual DbSet<Placement> Placements { get; set; }
        public virtual DbSet<StudentsCourses> StudentsCourses { get; set; }
        public virtual DbSet<Nos> Noses { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<MajorsNoses> MajorsNoses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Taskss>().Property(e => e.TaskGroup).ValueGeneratedOnAdd();

            // setting many to many relationship between Majors and Users Noses
            modelBuilder.Entity<MajorsNoses>()
               .HasOne(e => e.Major)
               .WithMany(e => e.MajorsNoses)
               .HasForeignKey(e => e.MajorId);

            modelBuilder.Entity<MajorsNoses>()
               .HasOne(e => e.Nos)
               .WithMany(e => e.MajorsNoses)
               .HasForeignKey(e => e.NosId);


            // setting primary key to TaskComment table
            modelBuilder.Entity<TasksComments>()
               .HasKey(e => new
               {
                   e.Id
               });

            // setting many to many relationship between Tasks and Users tables
            modelBuilder.Entity<TasksComments>()
               .HasOne(e => e.User)
               .WithMany(e => e.TasksComments)
               .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<TasksComments>()
               .HasOne(e => e.Task)
               .WithMany(e => e.TasksComments)
               .HasForeignKey(e => e.TaskId);

            // setting primary key to StudentsSkills table
            modelBuilder.Entity<StudentsCourses>()
               .HasKey(e => new
               {
                   e.StudentId,
                   e.CourseId
               });
            // setting many to many relationship between Skills and Students tables
            modelBuilder.Entity<StudentsCourses>()
               .HasOne(e => e.Student)
               .WithMany(e => e.StudentsCourses)
               .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<StudentsCourses>()
               .HasOne(e => e.Course)
               .WithMany(e => e.StudentsCourses)
               .HasForeignKey(e => e.CourseId);

            // setting primary key to CoursesSkills table
            modelBuilder.Entity<CoursesSkills>()
               .HasKey(e => new
               {
                   e.CourseId,
                   e.SkillId
               });
            // setting many to many relationship between Skills and Courses tables
            modelBuilder.Entity<CoursesSkills>()
               .HasOne(e => e.Course)
               .WithMany(e => e.CourseSkills)
               .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<CoursesSkills>()
               .HasOne(e => e.Skill)
               .WithMany(e => e.CourseSkills)
               .HasForeignKey(e => e.SkillId);

            

            // setting many to many relationship between Students, WorkMentors, SchoolMentors tables
            modelBuilder.Entity<Placement>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Placements)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Placement>()
                .HasOne(e => e.SchoolMentor)
                .WithMany(e => e.Placements)
                .HasForeignKey(e => e.SchoolMentorId);

            modelBuilder.Entity<Placement>()
                .HasOne(e => e.WorkMentor)
                .WithMany(e => e.Placements)
                .HasForeignKey(e => e.WorkMentorId);


            // setting many to many relationship Placement and Noses tables
            modelBuilder.Entity<PlacementsNoses>()
               .HasOne(e => e.Placement)
               .WithMany(e => e.PlacementsNoses)
               .HasForeignKey(e => e.PlacementId);

            modelBuilder.Entity<PlacementsNoses>()
               .HasOne(e => e.Nos)
               .WithMany(e => e.PlacementsNoses)
               .HasForeignKey(e => e.NosId);

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

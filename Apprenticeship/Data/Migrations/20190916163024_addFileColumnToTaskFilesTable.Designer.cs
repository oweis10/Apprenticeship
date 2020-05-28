﻿// <auto-generated />
using System;
using Apprenticeship.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apprenticeship.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190916163024_addFileColumnToTaskFilesTable")]
    partial class addFileColumnToTaskFilesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apprenticeship.Models.Course", b =>
                {
                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Apprenticeship.Models.CoursesSkills", b =>
                {
                    b.Property<long>("CourseId");

                    b.Property<long>("SkillId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("CourseId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CoursesSkills");
                });

            modelBuilder.Entity("Apprenticeship.Models.Degree", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Apprenticeship.Models.Lookups", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Text");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Lookups");
                });

            modelBuilder.Entity("Apprenticeship.Models.Major", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("Apprenticeship.Models.Nos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("PlacementId");

                    b.Property<string>("PlacementSchoolMentorId");

                    b.Property<string>("PlacementStudentId");

                    b.Property<string>("PlacementWorkMentorId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PlacementStudentId", "PlacementSchoolMentorId", "PlacementWorkMentorId");

                    b.ToTable("Noses");
                });

            modelBuilder.Entity("Apprenticeship.Models.Placement", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<string>("SchoolMentorId");

                    b.Property<string>("WorkMentorId");

                    b.Property<string>("CompanyName");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("StudentId", "SchoolMentorId", "WorkMentorId");

                    b.HasIndex("SchoolMentorId");

                    b.HasIndex("WorkMentorId");

                    b.ToTable("Placements");
                });

            modelBuilder.Entity("Apprenticeship.Models.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Apprenticeship.Models.StudentsCourses", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<long>("CourseId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("Apprenticeship.Models.TaskFiles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<long>("DeletedBy");

                    b.Property<byte[]>("File");

                    b.Property<bool>("Modified");

                    b.Property<long>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<long>("TaskId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskFiles");
                });

            modelBuilder.Entity("Apprenticeship.Models.TasksComments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<long>("TaskId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskComments");
                });

            modelBuilder.Entity("Apprenticeship.Models.Taskss", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<long>("DeletedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("Modified");

                    b.Property<long>("ModifiedBy");

                    b.Property<string>("Note");

                    b.Property<int>("Status");

                    b.Property<string>("StudentId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Apprenticeship.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address");

                    b.Property<string>("CompanyName");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("SecondName");

                    b.Property<long>("StudentId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Apprenticeship.Models.SchoolMentor", b =>
                {
                    b.HasBaseType("Apprenticeship.Models.User");

                    b.HasDiscriminator().HasValue("SchoolMentor");
                });

            modelBuilder.Entity("Apprenticeship.Models.Student", b =>
                {
                    b.HasBaseType("Apprenticeship.Models.User");

                    b.Property<long?>("DegreeId");

                    b.Property<string>("EmergencyContactFullName");

                    b.Property<string>("EmergencyContactPhoneNumber");

                    b.Property<long?>("MajorId");

                    b.HasIndex("DegreeId");

                    b.HasIndex("MajorId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Apprenticeship.Models.WorkMentor", b =>
                {
                    b.HasBaseType("Apprenticeship.Models.User");

                    b.HasDiscriminator().HasValue("WorkMentor");
                });

            modelBuilder.Entity("Apprenticeship.Models.CoursesSkills", b =>
                {
                    b.HasOne("Apprenticeship.Models.Course", "Course")
                        .WithMany("CourseSkills")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apprenticeship.Models.Skill", "Skill")
                        .WithMany("CourseSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apprenticeship.Models.Nos", b =>
                {
                    b.HasOne("Apprenticeship.Models.Placement", "Placement")
                        .WithMany("Noses")
                        .HasForeignKey("PlacementStudentId", "PlacementSchoolMentorId", "PlacementWorkMentorId");
                });

            modelBuilder.Entity("Apprenticeship.Models.Placement", b =>
                {
                    b.HasOne("Apprenticeship.Models.SchoolMentor", "SchoolMentor")
                        .WithMany("Placements")
                        .HasForeignKey("SchoolMentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apprenticeship.Models.Student", "Student")
                        .WithMany("Placements")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apprenticeship.Models.WorkMentor", "WorkMentor")
                        .WithMany("Placements")
                        .HasForeignKey("WorkMentorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apprenticeship.Models.StudentsCourses", b =>
                {
                    b.HasOne("Apprenticeship.Models.Course", "Course")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apprenticeship.Models.Student", "Student")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apprenticeship.Models.TaskFiles", b =>
                {
                    b.HasOne("Apprenticeship.Models.Taskss", "Task")
                        .WithMany("TaskFiles")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apprenticeship.Models.TasksComments", b =>
                {
                    b.HasOne("Apprenticeship.Models.Taskss", "Task")
                        .WithMany("TasksComments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Apprenticeship.Models.User", "User")
                        .WithMany("TasksComments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Apprenticeship.Models.Taskss", b =>
                {
                    b.HasOne("Apprenticeship.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Apprenticeship.Models.Student", b =>
                {
                    b.HasOne("Apprenticeship.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId");

                    b.HasOne("Apprenticeship.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId");
                });
#pragma warning restore 612, 618
        }
    }
}

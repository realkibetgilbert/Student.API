﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student.API.Data;

#nullable disable

namespace Student.API.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230629125112_c migration")]
    partial class cmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolMangement.API.Entities.CourseLecturer", b =>
                {
                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("LectureId")
                        .HasColumnType("bigint");

                    b.HasKey("CourseId", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("CourseLecturers");
                });

            modelBuilder.Entity("SchoolMangement.API.Entities.Lecture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Student.API.Entities.College", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("Student.API.Entities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Student.API.Entities.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SchoolId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Student.API.Entities.School", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CollegeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Student.API.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student.API.Entities.StudentCourse", b =>
                {
                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("SchoolMangement.API.Entities.CourseLecturer", b =>
                {
                    b.HasOne("Student.API.Entities.Course", "Course")
                        .WithMany("courseLecturers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMangement.API.Entities.Lecture", "Lecture")
                        .WithMany("Courses")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("SchoolMangement.API.Entities.Lecture", b =>
                {
                    b.HasOne("Student.API.Entities.Course", null)
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId");

                    b.HasOne("Student.API.Entities.Department", "Department")
                        .WithMany("Lectures")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Student.API.Entities.Course", b =>
                {
                    b.HasOne("Student.API.Entities.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Student.API.Entities.Department", b =>
                {
                    b.HasOne("Student.API.Entities.School", "School")
                        .WithMany("Departments")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Student.API.Entities.School", b =>
                {
                    b.HasOne("Student.API.Entities.College", "College")
                        .WithMany("Schools")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");
                });

            modelBuilder.Entity("Student.API.Entities.Student", b =>
                {
                    b.HasOne("Student.API.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Student.API.Entities.StudentCourse", b =>
                {
                    b.HasOne("Student.API.Entities.Course", "Course")
                        .WithMany("studentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.API.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolMangement.API.Entities.Lecture", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Student.API.Entities.College", b =>
                {
                    b.Navigation("Schools");
                });

            modelBuilder.Entity("Student.API.Entities.Course", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Students");

                    b.Navigation("courseLecturers");

                    b.Navigation("studentCourses");
                });

            modelBuilder.Entity("Student.API.Entities.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("Student.API.Entities.School", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Student.API.Entities.Student", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}

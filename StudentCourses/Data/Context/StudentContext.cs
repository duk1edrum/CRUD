using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Context
{
    public class StudentContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseToStudent> CoursesToStudents { get; set; }
    }

    //public class CourseDbInitializer : DropCreateDatabaseIfModelChanges<StudentContext>
    //{
    //    protected override void Seed(StudentContext context)
    //    {
    //        Student s1 = new Student{Name = "Asab",LastName = "Asssaa",Stipend = true,SizeStipend = 2200};
    //        Student s2 = new Student { Name = "Asab", LastName = "Bbbbbb", Stipend = true, SizeStipend = 2000 };
    //        Student s3 = new Student { Name = "Asab", LastName = "Ccccccc", Stipend = true, SizeStipend = 1800 };
    //        Student s4 = new Student { Name = "Asab", LastName = "Ddddddd", Stipend = true, SizeStipend = 1500 };

    //        context.Students.Add(s1);
    //        context.Students.Add(s2);
    //        context.Students.Add(s3);
    //        context.Students.Add(s4);

    //        Course c1 = new Course
    //        {
    //            CourseId = 1,
    //            Name = "MVC EntityFramework",
    //            Room = 13,
    //            Free = true,
    //            Students = new List<Student>() { s1,s2,}

    //        };
    //        Course c2 = new Course
    //        {
    //            CourseId = 2,
    //            Name = "Ado.Net",
    //            Room = 14,
    //            Free = false,
    //            Students = new List<Student>() { s2,s3,s4}

    //        };

    //        Course c3 = new Course
    //        {
    //            CourseId = 3,
    //            Name = "C# Essential",
    //            Room = 14,
    //            Free = false,
    //            Students = new List<Student>() { s1,s4}
    //        };

    //        context.Courses.Add(c1);
    //        context.Courses.Add(c2);
    //        context.Courses.Add(c3);

    //        context.SaveChanges(); 
    //    }
    }



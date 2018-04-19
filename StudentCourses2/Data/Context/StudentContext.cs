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
        public StudentContext():base("CrudDb")
        {
        }

        public StudentContext(string connectionString)
        :base("CrudDb")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User to Student One to Zero - or One to One 
            modelBuilder.Entity<Student>()
                .HasRequired(u => u.User)
                .WithOptional(u => u.Student);


            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(
                    p => p.Password)
                .HasMaxLength(20);

            //Many to Many Relations
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(s => s.Students)

                .Map(m =>
                {
                    m.ToTable("StudentsCoursesTable");
                    m.MapLeftKey("StudentId");
                    m.MapRightKey("CourseId");
                });

            base.OnModelCreating(modelBuilder);




        }
    }

    public class CourseDbInitializer : DropCreateDatabaseIfModelChanges<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            User user1 = new User
            {
                Name = "Qazxc",LastName = "Qwerty",Login = "qsc@qsc.com",Password = "1111",

            };

            Student student1 = new Student
            {
                Name = "Antov",
                LastName = "Antovonv",
                Stipend = true,
                Amount = 500,

            };

            Course course1 = new Course
            {
                Name = "Asp.Net MVC 6",
                Room = 12,
                Free = true,
            };

            context.Users.Add(user1);
            context.Students.Add(student1);
            context.Courses.Add(course1);
            context.SaveChanges();
        }
    }
    
        }



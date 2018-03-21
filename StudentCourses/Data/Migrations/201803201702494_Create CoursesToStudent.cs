namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCoursesToStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseId" });
            CreateTable(
                "dbo.CourseToStudents",
                c => new
                    {
                        CourseToStudentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseToStudentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            DropTable("dbo.StudentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId });
            
            DropForeignKey("dbo.CourseToStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseToStudents", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseToStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseToStudents", new[] { "CourseId" });
            DropTable("dbo.CourseToStudents");
            CreateIndex("dbo.StudentCourses", "Course_CourseId");
            CreateIndex("dbo.StudentCourses", "Student_StudentId");
            AddForeignKey("dbo.StudentCourses", "Course_CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}

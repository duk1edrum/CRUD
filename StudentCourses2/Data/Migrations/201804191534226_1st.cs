namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Room = c.Int(nullable: false),
                        Free = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        Stipend = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentsCoursesTable",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentId", "dbo.Users");
            DropForeignKey("dbo.StudentsCoursesTable", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentsCoursesTable", new[] { "CourseId" });
            DropIndex("dbo.StudentsCoursesTable", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropTable("dbo.StudentsCoursesTable");
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
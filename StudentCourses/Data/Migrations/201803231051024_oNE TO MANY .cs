namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oNETOMANY : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            AddColumn("dbo.Students", "CourseId", c => c.Int());
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "CourseId");
            DropColumn("dbo.Courses", "Student_StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Student_StudentId", c => c.Int());
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropColumn("dbo.Students", "CourseId");
            CreateIndex("dbo.Courses", "Student_StudentId");
            AddForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students", "StudentId");
        }
    }
}

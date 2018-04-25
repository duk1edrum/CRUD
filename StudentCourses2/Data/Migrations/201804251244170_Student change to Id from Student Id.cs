namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentchangetoIdfromStudentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "Id");
            AddPrimaryKey("dbo.Students", "StudentId");
            AddForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}

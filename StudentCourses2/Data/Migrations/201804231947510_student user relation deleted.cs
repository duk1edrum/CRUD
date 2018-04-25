namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentuserrelationdeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudentId", "dbo.Users");
            DropForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "User_Id", c => c.Int());
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Password", c => c.String());
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "User_Id");
            AddForeignKey("dbo.Students", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "User_Id", "dbo.Users");
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "User_Id");
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "StudentId");
            AddForeignKey("dbo.StudentsCoursesTable", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "StudentId", "dbo.Users", "Id");
        }
    }
}

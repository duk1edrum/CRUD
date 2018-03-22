namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyuserViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        UserViewId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserViewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserViewModels");
        }
    }
}

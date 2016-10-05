namespace PostProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostModels", "User_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            CreateIndex("dbo.PostModels", "User_Id");
            AddForeignKey("dbo.PostModels", "User_Id", "dbo.UserModels", "Id");
            DropColumn("dbo.PostModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostModels", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PostModels", "User_Id", "dbo.UserModels");
            DropIndex("dbo.PostModels", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.PostModels", "User_Id");
        }
    }
}

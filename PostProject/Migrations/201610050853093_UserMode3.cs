namespace PostProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMode3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PostModels", new[] { "User_Id" });
            AlterColumn("dbo.PostModels", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.PostModels", "User_Id");
            DropTable("dbo.UserModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.PostModels", new[] { "User_Id" });
            AlterColumn("dbo.PostModels", "User_Id", c => c.Int());
            CreateIndex("dbo.PostModels", "User_Id");
        }
    }
}

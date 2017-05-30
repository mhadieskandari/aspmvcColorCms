namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserIdFromCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropColumn("dbo.Carts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Carts", "User_Id");
            AddForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

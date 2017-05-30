namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationContentToApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contents", "UserID_Creator");
            AddForeignKey("dbo.Contents", "UserID_Creator", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "UserID_Creator", "dbo.AspNetUsers");
            DropIndex("dbo.Contents", new[] { "UserID_Creator" });
        }
    }
}

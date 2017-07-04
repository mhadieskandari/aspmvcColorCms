namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterAddUserIdToPayCoins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayCoins", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.PayCoins", "UserID");
            AddForeignKey("dbo.PayCoins", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayCoins", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.PayCoins", new[] { "UserID" });
            DropColumn("dbo.PayCoins", "UserID");
        }
    }
}

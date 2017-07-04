namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterChangePayCoin_PayIdToNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PayCoins", "PayId", "dbo.Pays");
            DropIndex("dbo.PayCoins", new[] { "PayId" });
            AlterColumn("dbo.PayCoins", "PayId", c => c.Int());
            CreateIndex("dbo.PayCoins", "PayId");
            AddForeignKey("dbo.PayCoins", "PayId", "dbo.Pays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayCoins", "PayId", "dbo.Pays");
            DropIndex("dbo.PayCoins", new[] { "PayId" });
            AlterColumn("dbo.PayCoins", "PayId", c => c.Int(nullable: false));
            CreateIndex("dbo.PayCoins", "PayId");
            AddForeignKey("dbo.PayCoins", "PayId", "dbo.Pays", "Id", cascadeDelete: true);
        }
    }
}

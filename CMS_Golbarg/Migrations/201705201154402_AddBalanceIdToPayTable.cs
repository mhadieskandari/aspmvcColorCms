namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceIdToPayTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pays", "Balance_Id", "dbo.Balances");
            DropIndex("dbo.Pays", new[] { "Balance_Id" });
            RenameColumn(table: "dbo.Pays", name: "Balance_Id", newName: "BalanceID");
            AlterColumn("dbo.Pays", "BalanceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pays", "BalanceID");
            AddForeignKey("dbo.Pays", "BalanceID", "dbo.Balances", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "BalanceID", "dbo.Balances");
            DropIndex("dbo.Pays", new[] { "BalanceID" });
            AlterColumn("dbo.Pays", "BalanceID", c => c.Int());
            RenameColumn(table: "dbo.Pays", name: "BalanceID", newName: "Balance_Id");
            CreateIndex("dbo.Pays", "Balance_Id");
            AddForeignKey("dbo.Pays", "Balance_Id", "dbo.Balances", "Id");
        }
    }
}

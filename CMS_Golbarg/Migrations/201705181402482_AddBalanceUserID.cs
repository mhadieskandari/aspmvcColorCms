namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceUserID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Balances", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Balances", name: "IX_User_Id", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Balances", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Balances", name: "UserID", newName: "User_Id");
        }
    }
}

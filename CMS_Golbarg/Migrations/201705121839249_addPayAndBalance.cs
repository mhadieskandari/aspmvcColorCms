namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPayAndBalance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BalanceNumber = c.String(),
                        State = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(nullable: false),
                        PayAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Boolean(nullable: false),
                        TransitionOfBankNumber = c.String(),
                        InOutType = c.Byte(nullable: false),
                        Balance_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balances", t => t.Balance_Id)
                .Index(t => t.Balance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pays", "Balance_Id", "dbo.Balances");
            DropIndex("dbo.Pays", new[] { "Balance_Id" });
            DropIndex("dbo.Balances", new[] { "User_Id" });
            DropTable("dbo.Pays");
            DropTable("dbo.Balances");
        }
    }
}

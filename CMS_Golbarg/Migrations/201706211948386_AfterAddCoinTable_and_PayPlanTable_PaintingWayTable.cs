namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterAddCoinTable_and_PayPlanTable_PaintingWayTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "PayId", "dbo.Pays");
            DropIndex("dbo.Carts", new[] { "PayId" });
            CreateTable(
                "dbo.PayPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlanName = c.String(),
                        PlanDes = c.String(),
                        Fi = c.Int(nullable: false),
                        NumberOfCoin = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaintingWays",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PayCoins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayId = c.Int(nullable: false),
                        NumberOfCoins = c.Int(nullable: false),
                        InOutType = c.Byte(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pays", t => t.PayId, cascadeDelete: true)
                .Index(t => t.PayId);
            
            AddColumn("dbo.Pays", "PayPlanId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "PayCoinId", c => c.Int(nullable: false));
            AddColumn("dbo.Mixers", "PaintingWayId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Pays", "PayPlanId");
            CreateIndex("dbo.Carts", "PayCoinId");
            CreateIndex("dbo.Mixers", "PaintingWayId");
            AddForeignKey("dbo.Pays", "PayPlanId", "dbo.PayPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "PayCoinId", "dbo.PayCoins", "Id", cascadeDelete: true);
            DropColumn("dbo.Carts", "PayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "PayId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "PayCoinId", "dbo.PayCoins");
            DropForeignKey("dbo.PayCoins", "PayId", "dbo.Pays");
            DropForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays");
            DropForeignKey("dbo.Pays", "PayPlanId", "dbo.PayPlans");
            DropIndex("dbo.PayCoins", new[] { "PayId" });
            DropIndex("dbo.Mixers", new[] { "PaintingWayId" });
            DropIndex("dbo.Carts", new[] { "PayCoinId" });
            DropIndex("dbo.Pays", new[] { "PayPlanId" });
            DropColumn("dbo.Mixers", "PaintingWayId");
            DropColumn("dbo.Carts", "PayCoinId");
            DropColumn("dbo.Pays", "PayPlanId");
            DropTable("dbo.PayCoins");
            DropTable("dbo.PaintingWays");
            DropTable("dbo.PayPlans");
            CreateIndex("dbo.Carts", "PayId");
            AddForeignKey("dbo.Carts", "PayId", "dbo.Pays", "Id", cascadeDelete: true);
        }
    }
}

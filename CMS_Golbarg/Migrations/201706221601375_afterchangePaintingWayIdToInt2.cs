namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterchangePaintingWayIdToInt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mixers", "PaintingWayId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mixers", "PaintingWayId");
            AddForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays");
            DropIndex("dbo.Mixers", new[] { "PaintingWayId" });
            DropColumn("dbo.Mixers", "PaintingWayId");
        }
    }
}

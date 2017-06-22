namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAutoIncreamentToPaintingwayId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays");
            DropPrimaryKey("dbo.PaintingWays");
            AlterColumn("dbo.PaintingWays", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.PaintingWays", "Id");
            AddForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays");
            DropPrimaryKey("dbo.PaintingWays");
            AlterColumn("dbo.PaintingWays", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.PaintingWays", "Id");
            AddForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays", "Id", cascadeDelete: true);
        }
    }
}

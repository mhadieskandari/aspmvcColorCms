namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterchangePaintingWayIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays");
            DropIndex("dbo.Mixers", new[] { "PaintingWayId" });
            DropColumn("dbo.Mixers", "PaintingWayId");
            DropTable("dbo.PaintingWays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaintingWays",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mixers", "PaintingWayId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Mixers", "PaintingWayId");
            AddForeignKey("dbo.Mixers", "PaintingWayId", "dbo.PaintingWays", "Id", cascadeDelete: true);
        }
    }
}

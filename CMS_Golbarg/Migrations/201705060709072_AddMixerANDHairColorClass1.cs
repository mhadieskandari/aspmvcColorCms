namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMixerANDHairColorClass1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HairColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorCode = c.String(nullable: false, maxLength: 5),
                        ColorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mixers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mix = c.String(nullable: false),
                        DeColor = c.String(nullable: false),
                        Oxidan = c.String(nullable: false),
                        InColor = c.String(nullable: false),
                        hairColor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HairColors", t => t.hairColor_Id, cascadeDelete: true)
                .Index(t => t.hairColor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mixers", "hairColor_Id", "dbo.HairColors");
            DropIndex("dbo.Mixers", new[] { "hairColor_Id" });
            DropTable("dbo.Mixers");
            DropTable("dbo.HairColors");
        }
    }
}

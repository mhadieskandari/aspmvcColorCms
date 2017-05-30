namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCartTable_ChangeMixProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mixers", "hairColor_Id", "dbo.HairColors");
            DropIndex("dbo.Mixers", new[] { "hairColor_Id" });
            RenameColumn(table: "dbo.Mixers", name: "hairColor_Id", newName: "ActualHairColor_Id");
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisterDate = c.DateTime(nullable: false),
                        ConfirmDate = c.DateTime(nullable: false),
                        Mixer_Id = c.Int(),
                        pay_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mixers", t => t.Mixer_Id)
                .ForeignKey("dbo.Pays", t => t.pay_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Mixer_Id)
                .Index(t => t.pay_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Mixers", "DestinationHairColor_Id", c => c.Int());
            AlterColumn("dbo.Mixers", "ActualHairColor_Id", c => c.Int());
            CreateIndex("dbo.Mixers", "ActualHairColor_Id");
            CreateIndex("dbo.Mixers", "DestinationHairColor_Id");
            AddForeignKey("dbo.Mixers", "DestinationHairColor_Id", "dbo.HairColors", "Id");
            AddForeignKey("dbo.Mixers", "ActualHairColor_Id", "dbo.HairColors", "Id");
            DropColumn("dbo.Mixers", "InColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mixers", "InColor", c => c.String(nullable: false));
            DropForeignKey("dbo.Mixers", "ActualHairColor_Id", "dbo.HairColors");
            DropForeignKey("dbo.Carts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carts", "pay_Id", "dbo.Pays");
            DropForeignKey("dbo.Carts", "Mixer_Id", "dbo.Mixers");
            DropForeignKey("dbo.Mixers", "DestinationHairColor_Id", "dbo.HairColors");
            DropIndex("dbo.Mixers", new[] { "DestinationHairColor_Id" });
            DropIndex("dbo.Mixers", new[] { "ActualHairColor_Id" });
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropIndex("dbo.Carts", new[] { "pay_Id" });
            DropIndex("dbo.Carts", new[] { "Mixer_Id" });
            AlterColumn("dbo.Mixers", "ActualHairColor_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Mixers", "DestinationHairColor_Id");
            DropTable("dbo.Carts");
            RenameColumn(table: "dbo.Mixers", name: "ActualHairColor_Id", newName: "hairColor_Id");
            CreateIndex("dbo.Mixers", "hairColor_Id");
            AddForeignKey("dbo.Mixers", "hairColor_Id", "dbo.HairColors", "Id", cascadeDelete: true);
        }
    }
}

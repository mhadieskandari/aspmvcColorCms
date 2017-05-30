namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMixerIdAndPayIdToCartTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Mixer_Id", "dbo.Mixers");
            DropForeignKey("dbo.Carts", "pay_Id", "dbo.Pays");
            DropIndex("dbo.Carts", new[] { "Mixer_Id" });
            DropIndex("dbo.Carts", new[] { "pay_Id" });
            RenameColumn(table: "dbo.Carts", name: "Mixer_Id", newName: "MixerId");
            RenameColumn(table: "dbo.Carts", name: "pay_Id", newName: "PayId");
            AlterColumn("dbo.Carts", "MixerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "PayId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "MixerId");
            CreateIndex("dbo.Carts", "PayId");
            AddForeignKey("dbo.Carts", "MixerId", "dbo.Mixers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "PayId", "dbo.Pays", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "PayId", "dbo.Pays");
            DropForeignKey("dbo.Carts", "MixerId", "dbo.Mixers");
            DropIndex("dbo.Carts", new[] { "PayId" });
            DropIndex("dbo.Carts", new[] { "MixerId" });
            AlterColumn("dbo.Carts", "PayId", c => c.Int());
            AlterColumn("dbo.Carts", "MixerId", c => c.Int());
            RenameColumn(table: "dbo.Carts", name: "PayId", newName: "pay_Id");
            RenameColumn(table: "dbo.Carts", name: "MixerId", newName: "Mixer_Id");
            CreateIndex("dbo.Carts", "pay_Id");
            CreateIndex("dbo.Carts", "Mixer_Id");
            AddForeignKey("dbo.Carts", "pay_Id", "dbo.Pays", "Id");
            AddForeignKey("dbo.Carts", "Mixer_Id", "dbo.Mixers", "Id");
        }
    }
}

namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActual_DestinationHairColorIdToMixer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Mixers", name: "ActualHairColor_Id", newName: "ActualHairColorID");
            RenameColumn(table: "dbo.Mixers", name: "DestinationHairColor_Id", newName: "DestinationHairColorID");
            RenameIndex(table: "dbo.Mixers", name: "IX_ActualHairColor_Id", newName: "IX_ActualHairColorID");
            RenameIndex(table: "dbo.Mixers", name: "IX_DestinationHairColor_Id", newName: "IX_DestinationHairColorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Mixers", name: "IX_DestinationHairColorID", newName: "IX_DestinationHairColor_Id");
            RenameIndex(table: "dbo.Mixers", name: "IX_ActualHairColorID", newName: "IX_ActualHairColor_Id");
            RenameColumn(table: "dbo.Mixers", name: "DestinationHairColorID", newName: "DestinationHairColor_Id");
            RenameColumn(table: "dbo.Mixers", name: "ActualHairColorID", newName: "ActualHairColor_Id");
        }
    }
}

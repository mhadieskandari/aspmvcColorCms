namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPicToHairColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairColors", "HairPic", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HairColors", "HairPic");
        }
    }
}

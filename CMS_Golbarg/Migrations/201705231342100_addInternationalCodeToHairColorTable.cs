namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInternationalCodeToHairColorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairColors", "InterNationalColorCode", c => c.String(maxLength: 5));
            AddColumn("dbo.HairColors", "InterNationalColorName", c => c.String());
            AddColumn("dbo.HairColors", "PersianColorCode", c => c.String(maxLength: 5));
            AddColumn("dbo.HairColors", "PersianColorName", c => c.String());
            DropColumn("dbo.HairColors", "ColorCode");
            DropColumn("dbo.HairColors", "ColorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HairColors", "ColorName", c => c.String(nullable: false));
            AddColumn("dbo.HairColors", "ColorCode", c => c.String(nullable: false, maxLength: 5));
            DropColumn("dbo.HairColors", "PersianColorName");
            DropColumn("dbo.HairColors", "PersianColorCode");
            DropColumn("dbo.HairColors", "InterNationalColorName");
            DropColumn("dbo.HairColors", "InterNationalColorCode");
        }
    }
}

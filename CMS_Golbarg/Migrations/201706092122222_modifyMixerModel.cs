namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMixerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mixers", "Mix", c => c.String());
            AlterColumn("dbo.Mixers", "DeColor", c => c.String());
            AlterColumn("dbo.Mixers", "Oxidan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mixers", "Oxidan", c => c.String(nullable: false));
            AlterColumn("dbo.Mixers", "DeColor", c => c.String(nullable: false));
            AlterColumn("dbo.Mixers", "Mix", c => c.String(nullable: false));
        }
    }
}

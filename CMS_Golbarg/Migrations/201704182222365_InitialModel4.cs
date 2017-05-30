namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contents", "Summury_Content", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "Summury_Content", c => c.String());
            AlterColumn("dbo.Contents", "Title", c => c.String());
        }
    }
}
